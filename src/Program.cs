//=======================================================================================
// GoodbyeUsp - data convertor database energy for import to Ukrbiling
// specification keys: 
// -export or - e --> only export data from database to files (if not specified -export=no)
// -export = no --> cancels generation output files (has priority over -export)
// -dbcreate = no -->  cancels recreate database and create tables
// -ren=an - processing of the specified REN (an-Андрушевский РЕМ, bn-Баранівський РЕМ, ...)
//=======================================================================================
// processing one by one:
//1) GoodbyeUsp.exe Server=10.67.5.10;Database=UkrBilling;Trusted_Connection=True; ./out/  -export=no -ren=an
//2) GoodbyeUsp.exe Server=10.67.5.10;Database=UkrBilling2;Trusted_Connection=True; ./out/ -dbcreate=no -export=no -ren=bn
// ...
//20) GoodbyeUsp.exe Server=10.67.5.10;Database=UkrBilling2;Trusted_Connection=True; ./out/ -dbcreate=no -export=no -ren=cd
// last step Export: GoodbyeUsp.exe Server=10.67.5.10;Database=UkrBilling2;Trusted_Connection=True; ./out/ -export
//
// notation:
// Server=10.67.5.10;Database=UkrBilling;Trusted_Connection=True; -> server and database
// ./out/ -> path for export files
//=======================================================================================
global using Microsoft.EntityFrameworkCore;
using GoodbyeUsp;
using GoodbyeUsp.Sources;
using Microsoft.Data.SqlClient;
using Dapper;
using GoodbyeUsp.Models;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using EFCore.BulkExtensions;
using System;

if (args.Length == 0)
{
    Console.WriteLine("Insufficiently parameters\nUsage: GoodbyeUsp <connstring merge db> [path for save files] [options]\nDefault path for files is './out', options: -e -export export only");
    return;
}
Console.WriteLine($"Using connection string '{args[0]}' for export DB");

var path = "./out/";
if (args.Length > 1 && !args[1].StartsWith('-'))
{
    path = args[1];
}
Console.WriteLine($"Using path '{path}' for export files");

if (Directory.Exists(path)) Directory.Delete(path, true);

var ci = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
ci.NumberFormat.NumberDecimalSeparator = ".";
Thread.CurrentThread.CurrentCulture = ci;

var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>().UseSqlServer(args[0]);

//-- find arg -ren=xx (prefix ren: an, bn, ...)
foreach (var item in args) {
    //Console.WriteLine("Current argument = "+item.ToString());
    if (item.IndexOf("-ren=") >= 0)
    {
        if (item.Length == 7)
        {
            Servers.renone = item.Substring(item.IndexOf("-ren=") + 5, 2);
            Console.WriteLine($"Using argument: -ren={Servers.renone}");
        }
        else
        {
            Console.WriteLine("Using argument: '-ren=' but the REN prefix is incorrect! The REN prefix must have 2 characters, example: an, bn ... ");
            return;
        }
    }
}

if (args.Any(a => new[] { "-dbcreate=no" }.Contains(a))) {
    Console.WriteLine($"Using argument: -dbcreate=no (Database will not be destroyed and created)");
}
if (args.Any(a => new[] { "-export=no" }.Contains(a)))
{
    Console.WriteLine($"Using argument: -export=no (Export files will not be created)");
}

Servers.LoadListConnStr();
var countren = Servers.ListConnStr.Count();
Console.WriteLine($"Count ren: {countren}");
//return;

using var ctx = new MainDbContext(optionsBuilder.Options);
if (!args.Any(a => new[] { "-export", "-e" }.Contains(a)))
{
    if (!args.Any(a => new[] { "-dbcreate=no" }.Contains(a)))
    {
        ctx.Database.EnsureDeleted();
        ctx.Database.Migrate();
        ctx.Database.ExecuteSqlRaw(@"ALTER DATABASE [UkrBilling3] MODIFY FILE ( NAME = N'UkrBilling3', SIZE = 2333312KB );");
        ctx.Database.ExecuteSqlRaw(@"ALTER DATABASE [UkrBilling3] MODIFY FILE ( NAME = N'UkrBilling3_log', SIZE = 2457312KB )");
        ctx.Database.SetCommandTimeout(0);
    }
    int IterNumber = 0;
    foreach (var cnString in Servers.ListConnStr)
    {
        Console.WriteLine(cnString);
        using var cn = new SqlConnection(cnString);

        var logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<Program>();
        logger.LogInformation("Conection string now - " + cnString);

        var recordpoints = cn.Query<Recordpoint>(Servers.SelectRecordpointQueryText, commandTimeout: 0)
            .GroupBy(rp => rp.NameRg)
            .Select(rp => new
            {
                Gregion = new Region
                {
                    Namerg = rp.Key
                },
                Streets = rp.GroupBy(rp => new
                {
                    rp.TypStr,
                    rp.NameStreet
                }).Select(r => new
                {
                    Street = new Street
                    {
                        TypeStr = r.Key.TypStr,
                        NameStr = r.Key.NameStreet
                    },
                    Recordpoints = r.GroupBy(rbs => new
                    {
                        rbs.LOCATIONHOUSE,
                        rbs.CodeEnergyReal
                    })
                })
            });

        logger.LogInformation("recordpoints count - " + recordpoints.Count().ToString());

        var recordpointTariffs = cn.Query<RecordpointTariff>(Servers.SelectTariffsQuery, commandTimeout: 0)
            .GroupBy(r => new { r.RecordpointId, r.StartDate })
            .Select(g => g.First())
            .GroupBy(r => r.RecordpointId);
        logger.LogInformation("recordpointTariffs count - " + recordpointTariffs.Count().ToString());

        foreach (var tr in recordpointTariffs)
        {
            IterNumber++;
            if (tr.Count() > 1)
            {
                DateTime? closeDate = null;
                foreach (var rp in tr.OrderByDescending(r => r.StartDate))
                {
                    if (closeDate is not null)
                    {
                        rp.EndDate = rp.StartDate < closeDate ? closeDate : rp.StartDate;
                    }
                    closeDate = rp.StartDate.AddDays(-1);
                }
            }
        }

        logger.LogInformation("End foreach recordpointTariffs IterNumber = " + IterNumber);

        ctx.AddRange(recordpointTariffs.SelectMany(rt => rt.Where(r => r.ConsumptionTypeId > 2))
            .GroupBy(r => r.RecordpointId)
            .Select(r => new Equipment
            {
                ClientId = r.Key,
                DateBegin = r.Min(e => e.StartDate),
            }));

        logger.LogInformation("End ctx.AddRange recordpointTariffs ");

        var typeTarifs = recordpointTariffs.SelectMany(rt => rt.Select(t => new TypeTarif
        {
            ClientId = rt.Key,
            DateBegin = t.StartDate,
            DateEnd = t.EndDate,
            CodeTypeTarif = t switch
            {
                { TariffName: var name } when name.Equals("апк", StringComparison.InvariantCultureIgnoreCase) => 19,
                { SettleTypeId: 1, TariffName: var name } when name.ToLower().Contains("основний") || name.ToLower().Contains("з нічним") => 12,
                { SettleTypeId: 2, TariffName: var name } when name.ToLower().Contains("основний") || name.ToLower().Contains("з нічним") => 11,
                { SettleTypeId: 2, ConsumptionTypeId: 2, TariffName: var name } when !name.ToLower().Contains("багатод") => 13,
                { SettleTypeId: 1, ConsumptionTypeId: 2, TariffName: var name } when !name.ToLower().Contains("багатод") => 14,
                { SettleTypeId: 2, ConsumptionTypeId: 1, TariffName: var name } when !name.ToLower().Contains("багатод") && name.ToLower().Contains("негаз") => 23,
                { SettleTypeId: 2, ConsumptionTypeId: 3, TariffName: var name } when !name.ToLower().Contains("багатод") => 25,
                { SettleTypeId: 1, ConsumptionTypeId: 3, TariffName: var name } when !name.ToLower().Contains("багатод") => 26,
                { SettleTypeId: 2, ConsumptionTypeId: 4, TariffName: var name } when !name.ToLower().Contains("багатод") => 31,
                { SettleTypeId: 1, ConsumptionTypeId: 4, TariffName: var name } when !name.ToLower().Contains("багатод") => 32,
                { SettleTypeId: 2, ConsumptionTypeId: 1, TariffName: var name } when name.ToLower().Contains("багатод") && !name.ToLower().Contains("негаз") => 111,
                { SettleTypeId: 1, ConsumptionTypeId: 1, TariffName: var name } when name.ToLower().Contains("багатод") && !name.ToLower().Contains("негаз") => 112,
                { SettleTypeId: 2, ConsumptionTypeId: 2, TariffName: var name } when name.ToLower().Contains("багатод") => 113,
                { SettleTypeId: 1, ConsumptionTypeId: 2, TariffName: var name } when name.ToLower().Contains("багатод") => 114,
                { SettleTypeId: 1, ConsumptionTypeId: 1, TariffName: var name } when !name.ToLower().Contains("багатод") && name.ToLower().Contains("негаз") => 123,
                { SettleTypeId: 2, ConsumptionTypeId: 3, TariffName: var name } when name.ToLower().Contains("багатод") => 125,
                { SettleTypeId: 1, ConsumptionTypeId: 3, TariffName: var name } when name.ToLower().Contains("багатод") => 126,
                { SettleTypeId: 2, ConsumptionTypeId: 4, TariffName: var name } when name.ToLower().Contains("багатод") => 131,
                { SettleTypeId: 1, ConsumptionTypeId: 4, TariffName: var name } when name.ToLower().Contains("багатод") => 132,
                { SettleTypeId: 2, ConsumptionTypeId: 1, TariffName: var name } when name.ToLower().Contains("багатод") && name.ToLower().Contains("негаз") => 137,
                { SettleTypeId: 1, ConsumptionTypeId: 1, TariffName: var name } when name.ToLower().Contains("багатод") && name.ToLower().Contains("негаз") => 139,
                _ => throw new NotImplementedException()
            }
        }));

        ctx.AddRange(typeTarifs.GroupBy(tt => new { tt.ClientId, tt.DateBegin }).Select(g => g.First()));

        foreach (var city in recordpoints)
        {
            var gregion = new Region
            {
                Namerg = city.Gregion.Namerg.Length > 27 ? city.Gregion.Namerg[..27] : city.Gregion.Namerg
            };

            ctx.Entry(gregion).State = EntityState.Added;

            foreach (var street in city.Streets)
            {
                var gstreet = new Street
                {
                    TypeStr = street.Street.TypeStr.Length > 3 ? street.Street.TypeStr[..3] : street.Street.TypeStr,
                    NameStr = street.Street.NameStr.Length > 27 ? street.Street.NameStr[..27] : street.Street.NameStr,
                };

                ctx.Entry(gstreet).State = EntityState.Added;

                foreach (var building in street.Recordpoints)
                {
                    var house = building.Key.LOCATIONHOUSE.Trim();
                    if (string.IsNullOrEmpty(house))
                        house = "0";

                    var houseNum = new string(building.Key.LOCATIONHOUSE.Trim().TakeWhile(char.IsDigit).ToArray());

                    if (string.IsNullOrEmpty(houseNum))
                        houseNum = "0";

                    if (houseNum.Length > 4)
                        houseNum = houseNum[..4];

                    var match = Regex.Match(house, @$"{houseNum}\s*((\w|-|/)+)$");
                    var disloc = new Disloc
                    {
                        Gregion = gregion,
                        GStreet = gstreet,
                        Nhouse = ushort.Parse(houseNum),
                        Charhouse = match.Success ? match.Groups[1].Value.ToUpper() : null,
                        Codeenergyareal = building.Key.CodeEnergyReal
                    };

                    ctx.Entry(disloc).State = EntityState.Added;

                    foreach (var recordpoint in building)
                    {
                        var flatNum = new string(recordpoint.LOCATIONAPP?.Trim()?.TakeWhile(char.IsDigit)?.ToArray());
                        string? flatChar = null;
#pragma warning disable CS8604 // Possible null reference argument.
                        if (!string.IsNullOrEmpty(flatNum))
                        {
                            var matchFlat = Regex.Match(recordpoint.LOCATIONAPP, @$"{flatNum}\s*((\w|-|/)+)$");
                            if (matchFlat.Success)
                                flatChar = match.Groups[1].Value.Length > 3 ? match.Groups[1].Value[..3] : match.Groups[1].Value;
                        }
#pragma warning restore CS8604 // Possible null reference argument.

                        var client = new Client
                        {
                            ClientId = recordpoint.ClientId,
                            Abcode = recordpoint.AbCode.Length > 18 ? recordpoint.AbCode[..18] : recordpoint.AbCode,
                            CodeEic = recordpoint.CodeEic.Length > 30 ? recordpoint.CodeEic[..30] : recordpoint.CodeEic,
                            CodeExchange = recordpoint.CodeExchange,
                            Datecreate = recordpoint.DateCreate,
                            Fio = recordpoint.Fio.Length > 50 ? recordpoint.Fio[..50] : recordpoint.Fio,
                            House = disloc,
                            Phone = recordpoint.Phone?.Length > 9 ? recordpoint.Phone[..9] : recordpoint.Phone,
                            CodeOwner = recordpoint.CodeOwner,
                            Nflat = !string.IsNullOrEmpty(flatNum) ? int.Parse(flatNum) : null,
                            Charflat = flatChar
                        };

                        ctx.Entry(client).State = EntityState.Added;

                        ctx.Add(new FactStart
                        {
                            Clientid = recordpoint.ClientId,
                            DateFact = new DateTime(2019, 1, 1),
                            Saldo = 0
                        });
                    }
                }
            }
        }

        #region Client consumptions
        var monthConsumptions = cn.Query<MonthConsum>(Servers.SelectConsumptionsQuery, commandTimeout: 0);
        ctx.AddRange(monthConsumptions);
        #endregion

        #region Citizens and their docs
        var c = cn.Query<Person>(Servers.SelectCitizensQuery)
            .Select(p => p.Build()).ToList()
            .Select(p => new Citizen
            {
                ClientId = p.ClientId,
                Fam = p.Fam,
                Name = p.Name,
                Otch = p.Otch,
                Vlad = p.Vlad,
                Docs = p.Docs.Select(d => new CopyDoc
                {
                    Codetype = d.Type,
                    DocDate = d.Date,
                    DocInstance = d.DocInstance,
                    DocNumber = d.Number
                }).ToList(),
            });

        ctx.AddRange(c);
        #endregion

        ctx.AddRange(cn.Query<Payment>(Servers.SelectPaymentsQuery, commandTimeout: 0));

        ctx.AddRange(cn.Query<Subsidy>(Servers.SelectSubsidyQuery, commandTimeout: 0));
        ctx.AddRange(cn.Query<Pay375>(Servers.SelectPay375Query, commandTimeout: 0));
        ctx.AddRange(cn.Query<Pay64>(Servers.SelectPay64Query, commandTimeout: 0));
        ctx.AddRange(cn.Query<MonetizedDiscount>(Servers.SelectMonetizedDiscounts, commandTimeout: 0));
        ctx.AddRange(cn.Query<GraphPay>(Servers.SelectDebtRestructingPlansQuery, commandTimeout: 0));


        try
        {
            using var transaction = ctx.Database.BeginTransaction();

            logger.LogInformation("Before insert data to BD");
            ctx.SaveChanges();
            transaction.Commit();
        }
        catch (Exception e)
        {
            logger.LogInformation("Error Message - " + e.Message);
        }


        logger.LogInformation("Affter insert data to BD");
        ctx.ChangeTracker.Clear();
        logger.LogInformation("Affter clear tracer");


    }
}
if (!args.Any(a => new[] { "-export=no" }.Contains(a)))
{
    Console.WriteLine("All data are collected, starting the export ...");
    new Exports(ctx, path).RunAll();
}
Console.WriteLine("All done.");

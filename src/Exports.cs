using GoodbyeUsp.Models;
using System.Text;

namespace GoodbyeUsp
{
    internal class Exports
    {
        internal class ClientExport
        {
            public int Clientid { get; set; } //int not null      - уникальный код лицевого счета
            public string Abcode { get; set; } //char (18) not null - номер лицевого счета
            public int Codehouse { get; set; } //int not null      - код дома ->tdisloc.codehouse
            public int? Nflat { get; set; } //int               - номер квартиры
            public string? Charflat { get; set; } //char (3)           - буква квартиры
            public string Fio { get; set; } //char (50) not null - ФИО владельца лицевого
            public string? Phone { get; set; } //  char (9)           - телефон
            public DateTime Datecreate { get; set; } //date not null     - дата создания лицевого счета
            public DateTime? Dateclose { get; set; } //date              - дата закрытия лицевого счета
            public int TypeSob { get; set; } = 0;//int not null      - тип собственности ->gproperty.typesob
            public int ClientTypeCode { get; set; } = 0; //int not null   -   0->бытовой абонент, 1->Юр.лицо
            public string CodeEic { get; set; } //char (30)          - код EIC
            public short CodeOwner { get; set; } //int not null      - код ЦОС(поставка) ->gfirme.codefirme
            public short CodeExchange { get; set; } //int not null      - код ОСР           ->gfirme.codefirme

            public override string ToString()
            {
                return $"{Clientid}|{Abcode}|{Codehouse}|{Nflat}|{Charflat}|{Fio}|{Phone}|{Datecreate:dd\\/MM\\/yyyy}|{Dateclose:dd\\/MM\\/yyyy}|{TypeSob}|{ClientTypeCode}|{CodeEic}|{CodeOwner}|{CodeExchange}|";
            }
        }

        readonly MainDbContext _dbContext;
        readonly string _path;
        

        public Exports(MainDbContext mainDbContext, string path = "./out/", uint pageSize = 5_000)
        {
            _path = path;
            if (!new[] { '/', '\\' }.Contains(_path.Last()))
                _path += '/';
            Directory.CreateDirectory(_path);
            _dbContext = mainDbContext;
        }

        public void ExportRegions()
        {
            File.WriteAllLines($"{_path}gregion.txt", _dbContext.Regions.AsNoTracking().ToArray().Select(r => r.ToString()), Encoding.GetEncoding(1251));
        }

        public void ExportStreets()
        {
            File.WriteAllLines($"{_path}gstreet.txt", _dbContext.Streets.AsNoTracking().ToArray().Select(r => r.ToString()), Encoding.GetEncoding(1251));
        }

        public void ExportDislocs()
        {
            File.WriteAllLines($"{_path}tdisloc.txt", _dbContext.Dislocs.AsNoTracking().ToArray().Select(r => r.ToString()), Encoding.GetEncoding(1251));
        }

        public void ExportEnergyAreal()
        {
            File.WriteAllLines($"{_path}genergyareal.txt", _dbContext.EnergyAreals.AsNoTracking().ToArray().Select(r => r.ToString()), Encoding.GetEncoding(1251));
        }

        public void ExportFirmes()
        {
            File.WriteAllLines($"{_path}gfirme.txt", _dbContext.Firmes.AsNoTracking().ToArray().Select(r => r.ToString()), Encoding.GetEncoding(1251));
        }

        public void ExportClients()
        {
            File.WriteAllLines($"{_path}tfactstart.txt", _dbContext.Clients.AsNoTracking().Select(r => r.FactStart.ToString()), Encoding.GetEncoding(1251));
            File.WriteAllLines($"{_path}ttypetarif.txt", _dbContext.Clients.AsNoTracking().SelectMany(r => r.TypeTarifs).Select(r => r.ToString()), Encoding.GetEncoding(1251));
            File.WriteAllLines($"{_path}tmonthconsum.txt", _dbContext.Clients.AsNoTracking().SelectMany(r => r.MonthConsums).Select(r => r.ToString()), Encoding.GetEncoding(1251));
            File.WriteAllLines($"{_path}tequipment.txt", _dbContext.Clients.AsNoTracking().SelectMany(r => r.Equipments).Select(r => r.ToString()), Encoding.GetEncoding(1251));
            File.WriteAllLines($"{_path}tpay.txt", _dbContext.Clients.AsNoTracking().SelectMany(r => r.Payments).Select(r => r.ToString()), Encoding.GetEncoding(1251));
            File.WriteAllLines($"{_path}tsubs.txt", _dbContext.Clients.AsNoTracking().SelectMany(r => r.Subsidies).Select(r => r.ToString()), Encoding.GetEncoding(1251));
            File.WriteAllLines($"{_path}tpay_375.txt", _dbContext.Clients.AsNoTracking().SelectMany(r => r.Pay375s).Select(r => r.ToString()), Encoding.GetEncoding(1251));
            File.WriteAllLines($"{_path}tpay_64.txt", _dbContext.Clients.AsNoTracking().SelectMany(r => r.Pay64s).Select(r => r.ToString()), Encoding.GetEncoding(1251));
            File.WriteAllLines($"{_path}tpay_monlg.txt", _dbContext.Clients.AsNoTracking().SelectMany(r => r.MonetizedDiscounts).Select(r => r.ToString()), Encoding.GetEncoding(1251));
            File.WriteAllLines($"{_path}tgraphpay.txt", _dbContext.Clients.AsNoTracking().SelectMany(r => r.GraphPays).Select(r => r.ToString()), Encoding.GetEncoding(1251));

            File.WriteAllLines($"{_path}tclient.txt", _dbContext.Clients.AsNoTracking()
                .Select(r => new ClientExport
                {
                    Abcode = r.Abcode,
                    Charflat = r.Charflat,
                    Clientid = r.ClientId,
                    ClientTypeCode = r.ClientTypeCode,
                    CodeEic = r.CodeEic,
                    CodeExchange = r.CodeExchange,
                    Codehouse = r.Codehouse,
                    CodeOwner = r.CodeOwner,
                    Dateclose = r.Dateclose,
                    Datecreate = r.Datecreate,
                    Fio = r.Fio,
                    Nflat = r.Nflat,
                    Phone = r.Phone,
                    TypeSob = r.TypeSob,
                })
                .ToArray()
                .Select(c => c.ToString()), Encoding.GetEncoding(1251));
        }

        public void ExportCitizens()
        {
            var citizens = _dbContext.Citizens
                .Include(c => c.Docs)
                .ToArray();
            File.WriteAllLines($"{_path}tcitizen.txt", citizens.Select(r => r.ToString()), Encoding.GetEncoding(1251));
            File.WriteAllLines($"{_path}tcopydoc.txt", citizens.SelectMany(r => r.Docs).Select(d => d.ToString()), Encoding.GetEncoding(1251));
        }

        public void RunAll()
        {
            ExportRegions();
            ExportStreets();
            ExportDislocs();
            ExportEnergyAreal();
            ExportFirmes();
            ExportClients();
            ExportCitizens();
        }
       
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodbyeUsp.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnergyAreals",
                columns: table => new
                {
                    CodeEnergyAreal = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyAreals", x => x.CodeEnergyAreal);
                });

            migrationBuilder.CreateTable(
                name: "Firmes",
                columns: table => new
                {
                    CodeFirme = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeGroup = table.Column<short>(type: "smallint", nullable: false),
                    NameFirme = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmes", x => x.CodeFirme);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Coder = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namerg = table.Column<string>(type: "varchar(27)", unicode: false, maxLength: 27, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Coder);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    CodeStreet = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStr = table.Column<string>(type: "varchar(27)", unicode: false, maxLength: 27, nullable: false),
                    TypeStr = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.CodeStreet);
                });

            migrationBuilder.CreateTable(
                name: "Dislocs",
                columns: table => new
                {
                    Codehouse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coder = table.Column<short>(type: "smallint", nullable: false),
                    Codestreet = table.Column<short>(type: "smallint", nullable: false),
                    Nhouse = table.Column<int>(type: "int", nullable: false),
                    Charhouse = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    Codehabit = table.Column<int>(type: "int", nullable: false),
                    Codejek = table.Column<int>(type: "int", nullable: false),
                    Nfloor = table.Column<int>(type: "int", nullable: true),
                    Codeenergyareal = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dislocs", x => x.Codehouse);
                    table.ForeignKey(
                        name: "FK_Dislocs_EnergyAreals_Codeenergyareal",
                        column: x => x.Codeenergyareal,
                        principalTable: "EnergyAreals",
                        principalColumn: "CodeEnergyAreal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dislocs_Regions_Coder",
                        column: x => x.Coder,
                        principalTable: "Regions",
                        principalColumn: "Coder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dislocs_Streets_Codestreet",
                        column: x => x.Codestreet,
                        principalTable: "Streets",
                        principalColumn: "CodeStreet",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Abcode = table.Column<string>(type: "varchar(18)", unicode: false, maxLength: 18, nullable: false),
                    Codehouse = table.Column<int>(type: "int", nullable: false),
                    Nflat = table.Column<int>(type: "int", nullable: true),
                    Charflat = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    Fio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    Datecreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dateclose = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeSob = table.Column<int>(type: "int", nullable: false),
                    ClientTypeCode = table.Column<int>(type: "int", nullable: false),
                    CodeEic = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    CodeOwner = table.Column<short>(type: "smallint", nullable: false),
                    CodeExchange = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Dislocs_Codehouse",
                        column: x => x.Codehouse,
                        principalTable: "Dislocs",
                        principalColumn: "Codehouse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Firmes_CodeExchange",
                        column: x => x.CodeExchange,
                        principalTable: "Firmes",
                        principalColumn: "CodeFirme",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Firmes_CodeOwner",
                        column: x => x.CodeOwner,
                        principalTable: "Firmes",
                        principalColumn: "CodeFirme",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    CitizenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Fam = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Otch = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Vlad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.CitizenId);
                    table.ForeignKey(
                        name: "FK_Citizens_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Codeequip = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => new { x.ClientId, x.Codeequip, x.DateBegin });
                    table.ForeignKey(
                        name: "FK_Equipments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactStarts",
                columns: table => new
                {
                    Clientid = table.Column<int>(type: "int", nullable: false),
                    DateFact = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactStarts", x => x.Clientid);
                    table.ForeignKey(
                        name: "FK_FactStarts_Clients_Clientid",
                        column: x => x.Clientid,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GraphPays",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphPays", x => new { x.ClientId, x.DateBegin });
                    table.ForeignKey(
                        name: "FK_GraphPays_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonetizedDiscounts",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateBank = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SummPay = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonetizedDiscounts", x => new { x.ClientId, x.DateBank });
                    table.ForeignKey(
                        name: "FK_MonetizedDiscounts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthConsumes",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeginDay = table.Column<int>(type: "int", nullable: false),
                    EndDay = table.Column<int>(type: "int", nullable: false),
                    Value1 = table.Column<int>(type: "int", nullable: false),
                    Value21 = table.Column<int>(type: "int", nullable: true),
                    Value22 = table.Column<int>(type: "int", nullable: true),
                    Value31 = table.Column<int>(type: "int", nullable: true),
                    Value32 = table.Column<int>(type: "int", nullable: true),
                    Value33 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthConsumes", x => new { x.ClientId, x.Month });
                    table.ForeignKey(
                        name: "FK_MonthConsumes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateBank = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SummPay = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
            //constraints: table =>
            //{
            //    table.PrimaryKey("PK_Payments", x => new { x.ClientId, x.DateBank });
            //    table.ForeignKey(
            //        name: "FK_Payments_Clients_ClientId",
            //        column: x => x.ClientId,
            //        principalTable: "Clients",
            //        principalColumn: "ClientId",
            //        onDelete: ReferentialAction.Cascade);
            //});
            constraints: table =>
            {
                table.PrimaryKey("PK_Payments", x => new { x.ClientId });
                table.ForeignKey(
                    name: "FK_Payments_Clients_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Clients",
                    principalColumn: "ClientId",
                    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable(
                name: "Payments375",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateBank = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SummPay = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments375", x => new { x.ClientId, x.DateBank });
                    table.ForeignKey(
                        name: "FK_Payments375_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments64",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateBank = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SummPay = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments64", x => new { x.ClientId, x.DateBank });
                    table.ForeignKey(
                        name: "FK_Payments64_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subsidies",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateBank = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SummPay = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsidies", x => new { x.ClientId, x.DateBank });
                    table.ForeignKey(
                        name: "FK_Subsidies_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeTarifs",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeTypeTarif = table.Column<short>(type: "smallint", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTarifs", x => new { x.ClientId, x.DateBegin });
                    table.ForeignKey(
                        name: "FK_TypeTarifs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitizenDocs",
                columns: table => new
                {
                    Citizenid = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codetype = table.Column<int>(type: "int", nullable: false),
                    DocNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    DocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocInstance = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenDocs", x => new { x.Citizenid, x.Id });
                    table.ForeignKey(
                        name: "FK_CitizenDocs_Citizens_Citizenid",
                        column: x => x.Citizenid,
                        principalTable: "Citizens",
                        principalColumn: "CitizenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EnergyAreals",
                columns: new[] { "CodeEnergyAreal", "Name" },
                values: new object[,]
                {
                    { (short)1, "Андрушівський РЕМ" },
                    { (short)2, "Баранівський РЕМ" },
                    { (short)3, "Бердичівський РЕМ" },
                    { (short)4, "Брусилівський РЕМ" },
                    { (short)5, "Хорошівський РЕМ" },
                    { (short)6, "Ємільчинський РЕМ" },
                    { (short)7, "Житомирський РЕМ" },
                    { (short)8, "Зарічанський РЕМ" },
                    { (short)9, "Коростенський РЕМ" },
                    { (short)11, "Коростишівський РЕМ" },
                    { (short)13, "Любарський РЕМ" },
                    { (short)14, "Малинський РЕМ" },
                    { (short)16, "Новоград-Волинський РЕМ" },
                    { (short)17, "Овруцький РЕМ" },
                    { (short)18, "Олевський РЕМ" },
                    { (short)19, "Попільнянський РЕМ" },
                    { (short)20, "Радомишльський РЕМ" },
                    { (short)21, "Романівський РЕМ" },
                    { (short)23, "Пулинський РЕМ" },
                    { (short)24, "Черняхівський РЕМ" },
                    { (short)25, "Чуднівський РЕМ" }
                });

            migrationBuilder.InsertData(
                table: "Firmes",
                columns: new[] { "CodeFirme", "CodeGroup", "NameFirme" },
                values: new object[,]
                {
                    { (short)101, (short)8, "АТ \"Житомирробленерго\"" },
                    { (short)102, (short)8, "АТ \"Укрзалізниця\"" },
                    { (short)201, (short)7, "Андрушівський ЦОК" },
                    { (short)202, (short)7, "Баранівський ЦОК" },
                    { (short)203, (short)7, "Бердичівський ЦОК" },
                    { (short)204, (short)7, "Брусилівський ЦОК" },
                    { (short)205, (short)7, "Хорошівський ЦОК" },
                    { (short)206, (short)7, "Ємільчинський ЦОК" },
                    { (short)207, (short)7, "Житомирський ЦОК" },
                    { (short)208, (short)7, "Зарічанський ЦОК" },
                    { (short)209, (short)7, "Коростенський ЦОК" },
                    { (short)211, (short)7, "Коростишівський ЦОК" },
                    { (short)213, (short)7, "Любарський ЦОК" },
                    { (short)214, (short)7, "Малинський ЦОК" },
                    { (short)216, (short)7, "Новоград-Волинський ЦОК" },
                    { (short)217, (short)7, "Овруцький ЦОК" },
                    { (short)218, (short)7, "Олевський ЦОК" },
                    { (short)219, (short)7, "Попільнянський ЦОК" },
                    { (short)220, (short)7, "Радомишльський ЦОК" },
                    { (short)221, (short)7, "Романівський ЦОК" },
                    { (short)223, (short)7, "Пулинський ЦОК" }
                });

            migrationBuilder.InsertData(
                table: "Firmes",
                columns: new[] { "CodeFirme", "CodeGroup", "NameFirme" },
                values: new object[] { (short)224, (short)7, "Черняхівський ЦОК" });

            migrationBuilder.InsertData(
                table: "Firmes",
                columns: new[] { "CodeFirme", "CodeGroup", "NameFirme" },
                values: new object[] { (short)225, (short)7, "Чуднівський ЦОК" });

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_ClientId",
                table: "Citizens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CodeExchange",
                table: "Clients",
                column: "CodeExchange");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Codehouse",
                table: "Clients",
                column: "Codehouse");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CodeOwner",
                table: "Clients",
                column: "CodeOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Dislocs_Codeenergyareal",
                table: "Dislocs",
                column: "Codeenergyareal");

            migrationBuilder.CreateIndex(
                name: "IX_Dislocs_Coder",
                table: "Dislocs",
                column: "Coder");

            migrationBuilder.CreateIndex(
                name: "IX_Dislocs_Codestreet",
                table: "Dislocs",
                column: "Codestreet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitizenDocs");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "FactStarts");

            migrationBuilder.DropTable(
                name: "GraphPays");

            migrationBuilder.DropTable(
                name: "MonetizedDiscounts");

            migrationBuilder.DropTable(
                name: "MonthConsumes");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Payments375");

            migrationBuilder.DropTable(
                name: "Payments64");

            migrationBuilder.DropTable(
                name: "Subsidies");

            migrationBuilder.DropTable(
                name: "TypeTarifs");

            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Dislocs");

            migrationBuilder.DropTable(
                name: "Firmes");

            migrationBuilder.DropTable(
                name: "EnergyAreals");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Streets");
        }
    }
}

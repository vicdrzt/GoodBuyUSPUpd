using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoodbyeUsp.Models
{
    internal class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientId { get; set; } //int not null      - уникальный код лицевого счета

        [Unicode(false)]
        [StringLength(18)]
        public string Abcode { get; set; } //char (18) not null - номер лицевого счета
        public int Codehouse { get; set; } //int not null      - код дома ->tdisloc.codehouse
        public int? Nflat { get; set; } //int               - номер квартиры

        [StringLength(3)]
        [Unicode(false)]
        public string? Charflat { get; set; } //char (3)           - буква квартиры

        [StringLength(50)]
        [Unicode(false)]
        public string Fio { get; set; } //char (50) not null - ФИО владельца лицевого

        [StringLength(9)]
        [Unicode(false)]
        public string? Phone { get; set; } //  char (9)           - телефон
        public DateTime Datecreate { get; set; } //date not null     - дата создания лицевого счета
        public DateTime? Dateclose { get; set; } //date              - дата закрытия лицевого счета
        public int TypeSob { get; set; } = 0;//int not null      - тип собственности ->gproperty.typesob
        public int ClientTypeCode { get; set; } = 0; //int not null   -   0->бытовой абонент, 1->Юр.лицо

        [StringLength(30)]
        [Unicode(false)]
        public string CodeEic { get; set; } //char (30)          - код EIC
        public short CodeOwner { get; set; } //int not null      - код ЦОС(поставка) ->gfirme.codefirme
        public short CodeExchange { get; set; } //int not null      - код ОСР           ->gfirme.codefirme
        public IEnumerable<Equipment> Equipments { get; set; }
        public Disloc House { get; set; }
        public FactStart FactStart { get; set; }
        public IEnumerable<TypeTarif> TypeTarifs { get; set; }
        public IEnumerable<MonthConsum> MonthConsums { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public IEnumerable<Pay375> Pay375s { get; set; }
        public IEnumerable<Pay64> Pay64s { get; set; }
        public IEnumerable<Subsidy> Subsidies { get; set; }
        public IEnumerable<MonetizedDiscount> MonetizedDiscounts { get; set; }
        public IEnumerable<GraphPay> GraphPays { get; set; }

        public override string ToString()
        {
            return $"{ClientId}|{Abcode}|{Codehouse}|{Nflat}|{Charflat}|{Fio}|{Phone}|{Datecreate:dd\\/MM\\/yyyy}|{Dateclose:dd\\/MM\\/yyyy}|{TypeSob}|{ClientTypeCode}|{CodeEic}|{CodeOwner}|{CodeExchange}|";
        }
    }
}

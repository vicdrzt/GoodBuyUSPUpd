namespace GoodbyeUsp.Models
{
    public class TypeTarif
    {
        public int ClientId { get; set; }
        public short CodeTypeTarif { get; set; } //smallint not null   - код типа тарифа ->gtypetarif.codetypetarif(сколько действующих тарифов - столько записей в справочнике типов тарифов)
        public DateTime DateBegin { get; set; } // date not null  - дата начала действия тарифа
        public DateTime? DateEnd { get; set; }  //date  - дата окончания действия тарифа
        public override string ToString()
        {
            return $"{ClientId}|{CodeTypeTarif}|{DateBegin:dd\\/MM\\/yyyy}|{DateEnd:dd\\/MM\\/yyyy}|";
        }
    }
}

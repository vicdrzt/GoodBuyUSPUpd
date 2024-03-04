namespace GoodbyeUsp.Sources
{
    internal class Recordpoint
    {
        public int ClientId { get; set; }
        public string AbCode { get; set; }
        public string CodeEic { get; set; }
        public string Fio { get; set; }
        public DateTime DateCreate { get; set; }
        public string NameRg { get; set; }
        public string TypStr { get; set; }
        public string NameStreet { get; set; }
        public string LOCATIONHOUSE { get; set; }
        public string LOCATIONAPP { get; set; }
        public string? Phone { get; set; }
        public short CodeExchange { get; set; }
        public short CodeEnergyReal { get; set; }
        public short CodeOwner { get; set; }
    }
}

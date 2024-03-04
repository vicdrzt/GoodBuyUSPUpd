namespace GoodbyeUsp.Models
{
    internal class GraphPay
    {
        public int ClientId { get; set; } //        int not null    ->tclient.clientid
        public DateTime DateBegin { get; set; }  //date not null   - начало графика, всегда 1-е число
        public DateTime DateEnd { get; set; } //date not null   - окончание графика, всегда 1-е число следующего месяца за
                                              //месяцем окончания рассрочки
                                              //    т.е.если начало графика 01.05.2011 и рассрочка дана
                                              //   на 5 месяцев то должно стоять 01.11.2011
        [Precision(16, 2)]
        public decimal Debt { get; set; } //dec() not null  - сумма на которую выдан график погашения

        public override string ToString() 
            => $"{ClientId}|{DateBegin:dd\\/MM\\/yyyy}|{DateEnd:dd\\/MM\\/yyyy}|{Debt:0.00}|";
    }
}

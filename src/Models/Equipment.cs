namespace GoodbyeUsp.Models
{
    public class Equipment
    {
        public int ClientId { get; set; }//int not null    ->tclient.clientid
        public int Codeequip { get; set; } = 81; //int not null    ->gequipment.codeequip
                                                 //codeequip=81  - наличие электроотопления у абонента,
                                                 //используется при расчете льготы в отопительные период при наличии электроотопления
                                                 //codeequip = 70 - допустимая мощность
        public int Value { get; set; } = 1; // dec() not null  - значение, в электроотоплении = 1
        public DateTime DateBegin { get; set; } //        date not null   - дата начала действия электроотопления
        public DateTime? DateEnd { get; set; }  //date - дата окончания действия электроотопления
        public override string ToString()
        {
            return $"{ClientId}|{Codeequip}|1|{DateBegin:dd\\/MM\\/yyyy}|{DateEnd:dd\\/MM\\/yyyy}|";
        }
    }
}

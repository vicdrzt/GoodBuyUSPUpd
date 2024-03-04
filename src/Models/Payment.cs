using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp.Models
{
    public class Payment
    {
        public int ClientId { get; set; } //int not null   ->tclient.clientid

        [Precision(16, 2)]
        public decimal SummPay { get; set; }     //dec() not null - сумма оплаты, может быть только ПОЛОЖИТЕЛЬНОЙ
                                                 //отрицательные величины будут отброшены
        public DateTime DateBank { get; set; }   //date not null  - дата оплаты

        public override string ToString()
        {
            return $"{ClientId}|{SummPay:0.00}|{DateBank:dd\\/MM\\/yyyy}|";
        }
    }
}

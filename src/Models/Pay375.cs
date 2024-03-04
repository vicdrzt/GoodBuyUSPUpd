using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp.Models
{
    internal class Pay375 //Компенсація за недотримання стандартів якості
    {
        public int ClientId { get; set; } // int not null   ->tclient.clientid
        
        [Precision(16, 2)]
        public decimal SummPay { get; set; } //  ec() not null - сумма оплаты, может быть только ПОЛОЖИТЕЛЬНОЙ
                                             //отицательные величины будут отброшены
        public DateTime DateBank { get; set; } //  date not null  - дата поступления

        public override string ToString()
        {
            return $"{ClientId}|{SummPay:0.00}|{DateBank:dd\\/MM\\/yyyy}|";
        }
    }
}

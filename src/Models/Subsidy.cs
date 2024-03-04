using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp.Models
{
    internal class Subsidy
    {
        public int ClientId { get; set; }//int not null   ->tclient.clientid

        [Precision(16, 2)]
        public decimal SummPay { get; set; } //dec() not null - сумма субсидии
        public DateTime DateBank { get; set; } //date not null  - дата поступления субсидии
        public DateTime? DateBegin { get; set; }  //date           - начало периода суммы субсидии
        public DateTime? DateEnd { get; set; }//{get;set;}date           - окончание периода суммы субсидии

        public override string ToString()
        {
            return $"{ClientId}|{SummPay:0.00}|{DateBank:dd\\/MM\\/yyyy}|{DateBegin:dd\\/MM\\/yyyy}|{DateEnd:dd\\/MM\\/yyyy}|";
        }
    }
}

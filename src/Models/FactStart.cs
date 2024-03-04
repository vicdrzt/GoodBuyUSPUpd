using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp.Models
{
    
    public class FactStart
    {
        public int Clientid { get; set; }//int not null   ->tclient.clientid
        public DateTime DateFact { get; set; } = new DateTime(2019, 1, 1); //    date not null  - дата старта(начало расчета абонента в системе)
        
        [Precision(16, 2)]
        public decimal Saldo { get; set; } //dec() not null - сальдо на дату старта(datefact)

        public override string ToString()
        {
            return $"{Clientid}|{DateFact:dd\\/MM\\/yyyy}|{Saldo:0\\.00}|";
        }
    }
}

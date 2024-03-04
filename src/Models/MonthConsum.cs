using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp.Models
{
    public class MonthConsum
    {
        public int ClientId { get; set; }//int not null  - tclient.clientid
        public DateTime Month { get; set; }      //date not null - месяц потребления(первое число соответствующего месяца, например 01.05.2020 - это май 2020)
        public int BeginDay { get; set; } //int not null  - начальный день периода в рамках месяца(включительно) число, от 1 до 31
        public int EndDay { get; set; } //int not null  - конечный день периода в рамках месяца(включительно) число, от 1 до 31 т.е.если период это полный месяц январь то begin = 1 end=31
        public int Value1 { get; set; } //dec()  - объем потребления(кВт* ч), по обычному(незонному) прибору учета или при отсутствии прибора учета за соответствующий период по состоянию "на сейчас"
        public int? Value21 { get; set; } //dec()  - счетчик 2-х зонный объем потребления по зоне "день" 
        public int? Value22 { get; set; } //dec()  - счетчик 2-х зонный объем потребления по зоне "ночь"
        public int? Value31 { get; set; } //dec()  - счетчик 3-х зонный объем потребления по зоне "пик"
        public int? Value32 { get; set; } //dec()  - счетчик 3-х зонный объем потребления по зоне "полупик"
        public int? Value33 { get; set; } // dec()  - счетчик 3-х зонный объем потребления по зоне "ночь"

        public override string ToString()
        {
            return $"{ClientId}|{Month:dd\\/MM\\/yyyy}|{BeginDay}|{EndDay}|{Value1}|{Value21}|{Value22}|{Value31}|{Value32}|{Value33}|";
        }
    }
}

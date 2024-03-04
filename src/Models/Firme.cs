using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp.Models
{
    public class Firme
    {
        [Key]
        public short CodeFirme { get; set; } //   -- уникальный код фирмы(1-й код занят под конвертацию)
        public short CodeGroup { get; set; } //   -- код группы(7-код группа Поставки, 8-код группа ОСР)

        [StringLength(100)]
        [Unicode(false)]
        public string NameFirme { get; set; }//char (100)  not null   -- наименование фирмы

        public override string ToString()
        {
            return $"{CodeFirme}|{CodeGroup}|{NameFirme}|";
        }
    }
}

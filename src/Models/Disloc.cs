using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp.Models
{
    public class Disloc
    {
        [Key]
        public int Codehouse { get; set; }      //-- уникальный код дома
        public short Coder { get; set; }  //-- код района, ->gregion.coder
        public short Codestreet { get; set; }  //-- код улицы,  ->gstreet.codestreet
        public ushort Nhouse { get; set; }  //-- номер дома

        [StringLength(9)]
        [Unicode(false)]
        public string? Charhouse { get; set; }           //-- char(9) буква дома(содержит только большие буквы и цифры, а так же знаки  / - )
        public int Codehabit { get; set; } = 0;      //-- тип жилья, ->ghabit.codehabit
        public int Codejek { get; set; } = 1;       //-- ЖЭК -> gjek.codejek(если нет данных - ставите 1)
        public int? Nfloor { get; set; }                //-- количество этажей, при отсутствии значения будет проставлено  1
        public short Codeenergyareal { get; set; }    //-- код РЭС(ЦОС)(подразделение компании) и внешних ОСР

        [ForeignKey("Coder")]
        public Region Gregion { get; set; }

        [ForeignKey("Codestreet")]
        public Street GStreet { get; set; }

        public override string ToString()
        {
            return $"{Codehouse}|{Coder}|{Codestreet}|{Nhouse}|{Charhouse}|{Codehabit}|{Codejek}|{Nfloor}|{Codeenergyareal}|";
        }
    }
}

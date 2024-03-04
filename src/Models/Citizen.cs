using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp.Models
{
    internal class Citizen
    {
        [Key]
        public int CitizenId { get; set; }//int not null       - уникальный код физ.лица
        public int ClientId { get; set; }   //int not null       ->tclient.clientid
        
        [StringLength(20)]
        [Unicode(false)]
        public string Fam { get; set; }     // char (20) not null  - фамилия

        [StringLength(20)]
        [Unicode(false)]
        public string? Name { get; set; }    //  char (20)           - имя

        [StringLength(20)]
        [Unicode(false)]
        public string? Otch { get; set; }     //  char (20)           - отчество
        public int Vlad { get; set; }     //int not null       - владелец лицевого счета, 1-владелец, 0-нет

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public IEnumerable<CopyDoc> Docs { get; set; }

        public override string ToString()
        {
            return $"{CitizenId}|{ClientId}|{Fam}|{Name}|{Otch}|{Vlad}|";
        }
    }
}

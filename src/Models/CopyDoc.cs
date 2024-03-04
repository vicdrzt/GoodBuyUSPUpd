using System.ComponentModel.DataAnnotations;
namespace GoodbyeUsp.Models
{
    public class CopyDoc
    {
        public int Citizenid { get; set; } //int not null - код физлица ->tcitizen.citizenid
        public int Codetype { get; set; }    //int not null - код типа документа ->gtypedocument.codetype (1 паспорт; 8 удостоверение льготника; 19 ИНН)

        [StringLength(15)]
        [Unicode(false)]
        public string DocNumber { get; set; }   //char (15)     - номер документа 
        public DateTime? DocDate { get; set; } //date         - дата выдачи документа
        
        [StringLength(50)]
        [Unicode(false)]
        public string? DocInstance { get; set; } //char (50)     - организация выдавшая документ
        public override string ToString()
        {
            return $"{Citizenid}|{Codetype}|{DocNumber}|{DocDate:dd\\/MM\\/yyyy}|{DocInstance}|";
        }
    }
}


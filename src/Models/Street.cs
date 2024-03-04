using System.ComponentModel.DataAnnotations;

namespace GoodbyeUsp.Models
{
    public class Street
    {
        [Key]
        public short CodeStreet { get; set; }
        
        [StringLength(27)]
        [Unicode(false)]
        public string NameStr { get; set; }

        [StringLength(3)]
        [Unicode(false)]
        public string TypeStr { get; set; }

        public override string ToString()
        {
            return $"{CodeStreet}|{TypeStr}|{NameStr}|";
        }
    }
}

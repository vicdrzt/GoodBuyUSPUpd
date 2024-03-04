using System.ComponentModel.DataAnnotations;
namespace GoodbyeUsp.Models
{
    public class Region
    {
        [Key]
        public short Coder { get; set; }

        [StringLength(27)]
        [Unicode(false)]
        public string Namerg { get; set; }

        public override string ToString()
        {
            return $"{Coder}|{Namerg}|";
        }
    }
}

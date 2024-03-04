using System.ComponentModel.DataAnnotations;

namespace GoodbyeUsp.Models
{
    public class EnergyAreal
    {
        [Key]
        public short CodeEnergyAreal { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{CodeEnergyAreal}|{Name}|";
        }
    }
}

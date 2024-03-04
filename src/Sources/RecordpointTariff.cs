using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeUsp.Sources
{
    internal class RecordpointTariff
    {
        public int RecordpointId { get; set; }
        public string TariffName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int SettleTypeId { get; set; }
        public int ConsumptionTypeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.BLL.DTO
{
    public class AirlineDTO
    {
        public Guid AirlineId { get; set; }
        public string AirlineName { get; set; } = string.Empty;
    }
}

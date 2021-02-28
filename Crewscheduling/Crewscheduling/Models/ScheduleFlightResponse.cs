using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrewScheduling.Models
{
    public class ScheduleFlightResponse
    {
        public int PilotId { get; set; }               
        public DateTime DepDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrewScheduling.Data
{
    public class Flight
    {
        public int PilotId { get; set; }      
        public DateTimeOffset DepDateTime { get; set; }
        public DateTimeOffset  ReturnDateTime { get; set; }
    }

    public class FlightList
    {
        public List<Flight> Flight { get; set; }
    }
}

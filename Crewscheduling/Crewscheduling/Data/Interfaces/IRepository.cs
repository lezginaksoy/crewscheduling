using CrewScheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrewScheduling.Data
{
    public interface IRepository
    {
        public CrewList GetPilotList();

        public FlightList GetFlightList();

        public void ScheduleFlight(FlightList flightList);

    }
}

using CrewScheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrewScheduling.Services
{
    public interface ISchedulingServices
    {
        public ApiResponse GetAvailablePilot(string location, DateTime depDateTime, DateTime returnDateTime);
        public ApiResponse ScheduleFlight(SchduleFlightRequest request);
    }
}

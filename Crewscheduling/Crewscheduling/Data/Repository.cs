using CrewScheduling.Constants;
using CrewScheduling.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrewScheduling.Data
{
    public class Repository : IRepository
    {
       public FlightList GetFlightList()
        {
            var jsontext = System.IO.File.ReadAllText(FileNames.FLIGHTS_PATH);
            
            var flights = JsonConvert.DeserializeObject<FlightList>(jsontext);
            return flights;           
        }

       public CrewList GetPilotList()
        {
            var jsontext = System.IO.File.ReadAllText(FileNames.CREW_PATH);
            var crew = JsonConvert.DeserializeObject<CrewList>(jsontext);
            return crew;
        }

        public void ScheduleFlight(FlightList flightList)
        {
            string jsonData = JsonConvert.SerializeObject(flightList, Formatting.None);
            System.IO.File.WriteAllText(FileNames.FLIGHTS_PATH, jsonData);
        }
    }
}

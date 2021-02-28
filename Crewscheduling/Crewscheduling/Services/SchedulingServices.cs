using CrewScheduling.Data;
using CrewScheduling.Enums;
using CrewScheduling.Helpers;
using CrewScheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrewScheduling.Services
{
    public class SchedulingServices : ISchedulingServices
    {
        private readonly IRepository _repository;

        public SchedulingServices(IRepository repository)
        {
            _repository = repository;
        }

        public ApiResponse GetAvailablePilot(string location, DateTime depDateTime, DateTime returnDateTime)
        {
            if (string.IsNullOrEmpty(location))
                return new ApiResponse(Errors.Location_InValid);
            if(!Helper.IsDepartureAndReturnDateValid(depDateTime,returnDateTime))
                return new ApiResponse(Errors.DepatureOrReturn_DateTime_InValid);

            var pilotList = _repository.GetPilotList();
            if (pilotList == null || pilotList.Crew.Count == 0)
                return new ApiResponse(Errors.Database_error);

            var flightList = _repository.GetFlightList();
            if (flightList == null || flightList.Flight.Count == 0)
                return new ApiResponse(Errors.Database_error);

            var day = Helper.GetDayOfWeek(depDateTime);
            var pilotListMatchedDay = pilotList.Crew.Where(x => x.Base.Equals(location) && x.WorkDays.Any(y => y.Contains(day))).ToList();
            if (pilotListMatchedDay.Count == 0)
                return new ApiResponse(Errors.Pilot_Not_Found);
     
            //find pilot with minimun flight
            int minFlightCount = int.MaxValue, AvailablePilotId = 0;
            foreach (var pilot in pilotListMatchedDay)
            {
                var flightExist = flightList.Flight.Any(x => x.PilotId == pilot.ID && x.DepDateTime.Equals(depDateTime) && x.ReturnDateTime.Equals(returnDateTime));
                if (!flightExist)
                {
                    var flightCount = flightList.Flight.Count(x => x.PilotId == pilot.ID);
                    if (flightCount <= minFlightCount)
                    {
                        minFlightCount = flightCount;
                        AvailablePilotId = pilot.ID;
                    }
                }
            }

            if (AvailablePilotId == 0)
                return new ApiResponse(Errors.Pilot_Not_Found);

            var response = new GetPilotResponse()
            {
                PilotId = AvailablePilotId,
                Location = location,
                DepDateTime = depDateTime,
                ReturnDateTime = returnDateTime
            };

            return new ApiResponse() { Result = response };
        }

        public ApiResponse ScheduleFlight(SchduleFlightRequest request)
        {
            if (request.PilotId == 0)
                return new ApiResponse(Errors.PilotId_InValid);

            if (!Helper.IsDepartureAndReturnDateValid(request.DepDateTime, request.ReturnDateTime))
                return new ApiResponse(Errors.DepatureOrReturn_DateTime_InValid);

            var pilotList = _repository.GetPilotList();
            if (pilotList == null || pilotList.Crew.Count == 0)
                return new ApiResponse(Errors.Database_error);

            var flightList = _repository.GetFlightList();
            if (flightList == null || flightList.Flight.Count == 0)
                return new ApiResponse(Errors.Database_error);

            var day = Helper.GetDayOfWeek(request.DepDateTime);
            var pilotMatched = pilotList.Crew.Any(x => x.ID == request.PilotId && x.WorkDays.Any(y => y.Contains(day)));
            if (!pilotMatched)
                return new ApiResponse(Errors.Pilot_Not_Found);

            var flightExist = flightList.Flight.Any(x => x.PilotId == request.PilotId && x.DepDateTime.Equals(request.DepDateTime) && x.ReturnDateTime.Equals(request.ReturnDateTime));
            if (flightExist)
                return new ApiResponse(Errors.Pilot_Schduled_Already);

            flightList.Flight.Add(new Flight { PilotId = request.PilotId, DepDateTime = request.DepDateTime, ReturnDateTime = request.ReturnDateTime });
            _repository.ScheduleFlight(flightList);

            var response = new ScheduleFlightResponse()
            {
                PilotId = request.PilotId,
                DepDateTime = request.DepDateTime,
                ReturnDateTime = request.ReturnDateTime
            };

            return new ApiResponse() { Result = response };

        }
    }
}

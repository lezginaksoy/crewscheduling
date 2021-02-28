using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrewScheduling.Data;
using CrewScheduling.Helpers;
using CrewScheduling.Models;
using CrewScheduling.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrewScheduling.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {

        private readonly ISchedulingServices _services;
        public SchedulingController(ISchedulingServices services)
        {
            _services = services;
        }

        [HttpGet("GetPilot")]
        public async Task<IActionResult> GetPilot(string Location, DateTime DepDateTime, DateTime ReturnDateTime)
        {
            var res = _services.GetAvailablePilot(Location, DepDateTime, ReturnDateTime);
            return Ok(res);

        }

        [HttpPost("SchduleFlight")]
        public async Task<IActionResult> SchduleFlight([FromBody] SchduleFlightRequest request)
        {
            var res = _services.ScheduleFlight(request);
            return Ok(res);
        }      
      
    }
}

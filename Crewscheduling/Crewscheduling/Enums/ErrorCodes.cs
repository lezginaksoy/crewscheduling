using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CrewScheduling.Enums
{  
    public enum Errors
    {
        [Description("Success")]
        Success = 0,
               
        [Description("Unknown Error")]
        Database_error = 7000,

        [Description("Pilot Not Found for given Dates")]
        Pilot_Not_Found = 1001,

        [Description("Pilot Scheduled already for given dates")]
        Pilot_Schduled_Already = 1002,             

        [Description("Departure Or Return DateTime is InValid")]
        DepatureOrReturn_DateTime_InValid = 1003,

        [Description("PilotId InValid")]
        PilotId_InValid = 1004,

        [Description("Location InValid")]
        Location_InValid = 1005
    }
}

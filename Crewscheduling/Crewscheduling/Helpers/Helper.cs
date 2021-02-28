using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrewScheduling.Helpers
{
    public static class Helper
    {
        public static string GetDayOfWeek(DateTime dateTime)
        {
            return dateTime.ToString("dddd");
        }

        public static bool IsDepartureAndReturnDateValid(DateTime depDateTime, DateTime retDateTime)
        {
            bool retVal = false;
            if (depDateTime != new DateTime() && retDateTime != new DateTime())
                retVal = true;
            if (depDateTime < retDateTime)
                retVal = true;

            return retVal;
        }

    }
}

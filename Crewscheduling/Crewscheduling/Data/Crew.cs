using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrewScheduling.Data
{     
    public class Crew
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Base { get; set; }
        public List<string> WorkDays { get; set; }
    }

    public class CrewList
    {
        public List<Crew> Crew { get; set; }
    }

}

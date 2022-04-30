using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Domain_Layer.DTO_S.Admin
{
    public class GraphDataDto
    {
        public GraphDataDto()
        {
            CallIn = new List<int>();
            CallOut = new List<int>();
            CallName = new List<string>();
        }
        public int ClientTypeCount { get; set; }
        public int ClientCount { get; set; }
        public int EmployeeCount { get; set; }
        public int CallCount { get; set; }
        public int CallInCount { get; set; }
        public int CallOutCount { get; set; }
        public List<GraphDataTime> GraphDataTime { get; set; }
        public List<int> CallIn { get; set; }   
        public List<int> CallOut { get; set; }   
        
        public List<string> CallName { get; set; }

    }
    public class GraphDataTime
    {
        public GraphDataTime()
        {
            date = new DateTime();
        }
        public int DurationNumber { get; set; }
        public int Count { get; set; }
        public int CallInCount { get; set; }
        public int CallOutCount { get; set; }
        public DateTime date { get; set; } 
        //public object test { get; set; }

    }
}
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Data_Access_Layer.Models
{
    [Keyless]
    public class AgentReportResponseSP
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int NumberOfCall { get; set; }
        public string ANG_Call_Duration { get; set; }
    }

    [Keyless]
    public class CallReasonReportResponseSP
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfCall { get; set; }
    }
}

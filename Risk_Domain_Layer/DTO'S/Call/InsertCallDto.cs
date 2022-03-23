using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Domain_Layer.DTO_S.Call
{
    public class InsertCallDto
    {

        public string Reason { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public bool Satisfy { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public string Start { get; set; }

        public string End { get; set; }

        public int CallReasonId { get; set; }
        public int CallType { get; set; }

        public int SourceMarketId { get; set; }
        public string customerId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Domain_Layer.DTO_S.Admin
{
    public class ClientCallSearchInputReportDto
    {
        public string? ClientName { get; set; }
        public string? Mobile { get; set; }
        public int? ClientType { get; set; }
        public int? Governorate { get; set; }
        public int? City { get; set; }
        public int? CallReasons { get; set; }
        public DateTime? CallDateFrom { get; set; }
        public DateTime? CallDateTo { get; set; } 
    }  
}

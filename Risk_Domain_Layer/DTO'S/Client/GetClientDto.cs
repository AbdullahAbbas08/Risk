using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Domain_Layer.DTO_S.Client
{
    public class GetClientDto
    { 
        public string ClientId { get; set; }
        public string LogoPath { get; set; }
         
        public int CityId { get; set; }
        public int GovernorateId { get; set; } 
        public string CityTitle { get; set; }
        public string GovernorateTitle { get; set; }

        public int ClientTypeId { get; set; }
        public string ClientTypeTitle { get; set; }

        public string Name { get; set; } 

        public string Mobile { get; set; }

        public string Address { get; set; }
        public string UserName { get; set; }
        public string password  { get; set; }

    }
}
 
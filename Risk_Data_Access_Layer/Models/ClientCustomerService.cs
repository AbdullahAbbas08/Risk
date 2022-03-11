using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Data_Access_Layer.Models
{
    public class ClientCustomerService
    {
        public int Id  { get; set; } 
        public string ClientId { get; set; }

        
        [ForeignKey("ClientId"),JsonIgnore]
        public Client client { get; set; }

        public string CustomerServiseId { get; set; }

        [ForeignKey("CustomerServiseId"), JsonIgnore]
        public CustomerServise customerServise { get; set; }
    }
}

 
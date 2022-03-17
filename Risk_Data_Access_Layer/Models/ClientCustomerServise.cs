using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Data_Access_Layer.Models
{
    public class ClientCustomerServise
    {
        public int Id { get; set; } 
        public string ClientId { get; set; }

        public string CustomerId { get; set; } 

        
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        
        [ForeignKey("CustomerId")]
        public virtual Employee Customer { get; set; }
    } 

}

 
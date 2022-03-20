using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Data_Access_Layer.Models
{
    public  class CustomerPhones
    {
        public int id { get; set; }
       

        public int MobileId { get; set; }

        [ForeignKey("MobileId")]
        public virtual MobilePhone MobilePhone { get; set; }

        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

    }
}

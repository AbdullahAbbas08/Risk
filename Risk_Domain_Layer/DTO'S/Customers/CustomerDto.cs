using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Domain_Layer.DTO_S.Customers
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string mobile { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public int CityId { get; set; }
        public DateTime DOB { get; set; }
    }
}

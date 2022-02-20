using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Domain_Layer.DTO_S
{
    public class GeneralResponse<T>
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}

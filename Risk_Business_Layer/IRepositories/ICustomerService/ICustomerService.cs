using Risk_Domain_Layer.DTO_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.IRepositories.ICustomerService
{
    public interface ICustomerService
    {
        Task AddRange(List<ClientCustomerService> idName);
    }

}

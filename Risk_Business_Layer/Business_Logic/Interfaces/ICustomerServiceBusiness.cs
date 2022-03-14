using Risk_Domain_Layer.DTO_S.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Business_Logic.Interfaces
{
    public interface ICustomerServiceBusiness
    {
        Task AddRange(ClientCustomerServise model);
        GeneralResponse<Client_Name_Id> GetCustomerRelatedWithAgent(string Id);
    }
}

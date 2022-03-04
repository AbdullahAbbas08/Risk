using Risk_Domain_Layer.DTO_S.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Business_Logic.Interfaces
{
    public interface IClientBusiness
    {
        Task AssignClientToAgent(Client Entity);
        Task<GeneralResponse<GetClientDto>> GetAll();

    }
}

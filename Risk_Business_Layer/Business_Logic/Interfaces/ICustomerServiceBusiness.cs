using Risk_Domain_Layer.DTO_S;
using Risk_Domain_Layer.DTO_S.ClientCustomerService;

namespace Risk_Business_Layer.Business_Logic.Interfaces
{
    public interface ICustomerServiceBusiness
    {
        Task AddRange(ClientCustomerServise model);
        GeneralResponse<ClientDto> GetCustomerRelatedWithAgent(string Id);
        GeneralResponse<IdNameList> GetClientsRelatedWithAgent(string Id);
    }
}
  
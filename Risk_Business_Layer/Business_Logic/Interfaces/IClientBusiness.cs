using Risk_Business_Layer.Services.Authentication;
using Risk_Domain_Layer.DTO_S;
using Risk_Domain_Layer.DTO_S.Client;
namespace Risk_Business_Layer.Business_Logic.Interfaces
{
    public interface IClientBusiness
    {
        Task AssignClientToAgent(Client Entity);
        Task<GeneralResponse<GetClientDto>> GetAll();
        Task<GeneralResponse<IdNameList>> GetAllIdName();
        Task<GeneralResponseSingleObject<EmptyResponse>> DeleteClient(string ID);
    }
}

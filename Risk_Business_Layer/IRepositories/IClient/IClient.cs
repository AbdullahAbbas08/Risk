using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Business_Layer.Services.Authentication;
using Risk_Domain_Layer.DTO_S.Client;
namespace Risk_Business_Layer.IRepositories.IClient
{
    public interface IClient: ICrud<Client>
    {
        Task<IEnumerable<GetClientDto>> GetAllWithRelatedTitles();
        bool DeleteUser(string ID);
        Task<GeneralResponseSingleObject<Client>> UpdateUser(UpdateClientModel model);
    }
}

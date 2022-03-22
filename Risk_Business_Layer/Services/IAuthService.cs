using Risk_Business_Layer.Services.Authentication;
using Risk_Business_Layer.Services.AuthenticationModels;
using Risk_Domain_Layer.DTO_S.Client;

namespace Risk_Business_Layer.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterEmployee(RegisterEmployeeModel model);
        Task<AuthModel> RegisterClient(RegisterClientModel model);
        Task<AuthModel> Login(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<GeneralResponseSingleObject<UpdateEmployee>> UpdateEmployee(UpdateEmployee model);
        Task<GeneralResponseSingleObject<UpdateClientModel>> UpdateClient(UpdateClientDto Entity);
        Task<GeneralResponseSingleObject<string>> RegisterCustomer(RegisterCustomerModel model);

    }
} 

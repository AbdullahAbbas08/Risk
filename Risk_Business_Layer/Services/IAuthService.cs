using Risk_Business_Layer.Services.Authentication;

namespace Risk_Business_Layer.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterEmployee(RegisterEmployeeModel model);
        Task<AuthModel> RegisterClient(RegisterClientModel model);
        Task<AuthModel> Login(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
} 

using Microsoft.Extensions.Configuration;
using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Business_Layer.IRepositories.ICustomerService;
using Risk_Business_Layer.Services;
using Risk_Data_Access_Layer;
using Risk_Domain_Layer.DTO_S;
using Risk_Domain_Layer.DTO_S.ClientCustomerService;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class CustomerServiceBusiness : ICustomerServiceBusiness
    {
        private readonly ICustomerService customerService;
        private readonly RiskDbContext riskDbContext;
        private readonly IConfiguration configuration;

        public CustomerServiceBusiness(ICustomerService customerService , RiskDbContext riskDbContext, IConfiguration Configuration)
        {
            this.customerService = customerService;
            this.riskDbContext = riskDbContext;
            configuration = Configuration;
        }

        public async Task AddRange(ClientCustomerServise model)
        {
            await riskDbContext.AddAsync(model);
           await riskDbContext.SaveChangesAsync();
        }

        public GeneralResponse<IdNameList> GetClientsRelatedWithAgent(string Id)
        {
            GeneralResponse<IdNameList> response = new GeneralResponse<IdNameList>();
            List<string> ClientIDs = new List<string>();
            var output = riskDbContext.ClientCustomerServise.Where(x => x.CustomerId == Id).ToList();
            ClientIDs = output.Select(x => x.ClientId).ToList();
            response.Data = riskDbContext.Clients.Where(x => ClientIDs.Contains(x.Id)).Select(o => new IdNameList { Id = o.Id,Name=o.Name }).ToList();
            response.Message = "Success";
            return response;
        }

        public GeneralResponse<ClientDto> GetCustomerRelatedWithAgent(string Toaken)
        {
            GeneralResponse<ClientDto> response = new GeneralResponse<ClientDto>();
            List<string> ClientIDs = new List<string>();
            string Id = AuthService.GetPrincipal(Toaken, configuration);
            var output = riskDbContext.ClientCustomerServise.Where(x => x.CustomerId == Id).ToList();
            ClientIDs = output.Select(x => x.ClientId).ToList();
            response.Data = riskDbContext.Clients.Where(x=>ClientIDs.Contains(x.Id)).Select(o=>new ClientDto { id = o.Id, name = o.Name , logo_path = o.LogoPath }).ToList();
            response.Message = "Success";
            return response;
        }
    }
}

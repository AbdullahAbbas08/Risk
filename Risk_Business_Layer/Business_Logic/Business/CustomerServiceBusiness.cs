using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Business_Layer.IRepositories.ICustomerService;
using Risk_Data_Access_Layer;
using Risk_Domain_Layer.DTO_S.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class CustomerServiceBusiness : ICustomerServiceBusiness
    {
        private readonly ICustomerService customerService;
        private readonly RiskDbContext riskDbContext;

        public CustomerServiceBusiness(ICustomerService customerService , RiskDbContext riskDbContext)
        {
            this.customerService = customerService;
            this.riskDbContext = riskDbContext;
        }

        public async Task AddRange(ClientCustomerServise model)
        {
            await riskDbContext.AddAsync(model);
           await riskDbContext.SaveChangesAsync();
        }

        public GeneralResponse<Client_Name_Id> GetCustomerRelatedWithAgent(string Id)
        {
            GeneralResponse<Client_Name_Id> response = new GeneralResponse<Client_Name_Id>();
            List<string> ClientIDs = new List<string>();
            var output = riskDbContext.ClientCustomerServise.Where(x => x.CustomerId == Id).ToList();
            ClientIDs = output.Select(x => x.ClientId).ToList();
            response.Data = riskDbContext.Clients.Where(x=>ClientIDs.Contains(x.Id)).Select(o=>new Client_Name_Id { id = o.Id, name = o.Name }).ToList();
            response.Message = "Success";
            return response;
        }
    }
}

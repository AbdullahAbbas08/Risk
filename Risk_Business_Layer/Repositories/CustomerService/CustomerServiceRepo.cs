using Risk_Business_Layer.IRepositories.ICustomerService;
using Risk_Business_Layer.Repositories.Crud;
using Risk_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Repositories.CustomerServices
{
    public class CustomerServiceRepo : Crud<CustomerServise>, ICustomerService
    {
        private readonly RiskDbContext riskDbContext;

        public CustomerServiceRepo(RiskDbContext riskDbContext) : base(riskDbContext)
        {
            this.riskDbContext = riskDbContext;
        }

        public async Task AddRange(List<ClientCustomerService> Entity)
        {
            await riskDbContext.AddRangeAsync(Entity);
            await riskDbContext.SaveChangesAsync();
        }
    } 
}
  
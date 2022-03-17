using Microsoft.EntityFrameworkCore;
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
    public class CustomerServiceRepo : Crud<Employee>, ICustomerService
    {
        private readonly RiskDbContext riskDbContext;
        private readonly IUnitOfWork_Crud unitOfWork;

        public CustomerServiceRepo(RiskDbContext riskDbContext,IUnitOfWork_Crud unitOfWork) : base(riskDbContext)
        {
            this.riskDbContext = riskDbContext;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddRange(List<ClientCustomerServise> Entity)
        {
            try
            {
                var query = (from x in riskDbContext.ClientCustomerServise where x.CustomerId == Entity[0].CustomerId select x).AsNoTracking().ToList();
                if (query.Count() != 0)
                    riskDbContext.ClientCustomerServise.RemoveRange(query);

                await riskDbContext.ClientCustomerServise.AddRangeAsync(Entity);
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
          
        }
    } 
}
  
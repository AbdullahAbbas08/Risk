using Microsoft.EntityFrameworkCore;
using Risk_Business_Layer.IRepositories.ICustomer;
using Risk_Business_Layer.Repositories.Crud;
using Risk_Data_Access_Layer;
using Risk_Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Repositories.Customer
{
    public class OuterCustomer : Crud<CustomerPhones>, ICustomer
    {
        private readonly RiskDbContext riskDbContext;
        private readonly IUnitOfWork_Crud unitOfWork; 

        public OuterCustomer(RiskDbContext riskDbContext, IUnitOfWork_Crud unitOfWork) : base(riskDbContext)
        {
            this.riskDbContext = riskDbContext; 
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> AddRange(List<(string,string)> model)
        {
            try
            {
                var query = (from x in riskDbContext.MobilePhones where x.CustomerId == model[0].Item1  select x).AsNoTracking().ToList();
                if (query.Count() != 0)
                    riskDbContext.MobilePhones.RemoveRange(query);

                List<MobilePhone> customerPhones = new List<MobilePhone>();
                foreach (var item in model)
                {
                    customerPhones.Add(new MobilePhone { CustomerId = item.Item1 , Mobile  = item.Item2});
                }
                await riskDbContext.MobilePhones.AddRangeAsync(customerPhones);
                await unitOfWork.SaveChangesAsync();
                return "تم إضافة أرقام الموبايل بنجاح ";
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

       
    }
}
 
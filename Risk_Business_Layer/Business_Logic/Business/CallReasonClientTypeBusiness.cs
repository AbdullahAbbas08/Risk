using Microsoft.EntityFrameworkCore;
using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Data_Access_Layer;
using Risk_Domain_Layer.DTO_S.CallReasonClientType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class CallReasonClientTypeBusiness : ICallReasonClientTypeBusiness
    {
        private readonly RiskDbContext riskDbContext;

        public CallReasonClientTypeBusiness(RiskDbContext riskDbContext) 
        {
            this.riskDbContext = riskDbContext;
        }

        public async Task AddAsync(List<CallReasonClientTypeDto> model)
        {
            try
            {
                var query = (from x in riskDbContext.CallReasonClientType 
                             where x.CallReasonId == model[0].CallReasonId 
                             select x).ToList();

                if (query.Count() != 0)
                    riskDbContext.CallReasonClientType.RemoveRange(query);

                List<CallReasonClientType> list = new List<CallReasonClientType>();
                foreach (var item in model)
                {
                    list.Add(new CallReasonClientType { CallReasonId = item.CallReasonId , ClientTypeId = item.ClientTypeId});
                }
                await riskDbContext.CallReasonClientType.AddRangeAsync(list);
                //await unitOfWork.SaveChangesAsync();
                riskDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

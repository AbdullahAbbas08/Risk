using Risk_Domain_Layer.DTO_S.CallReason;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.IBusiness_Logic.Interfaces
{
    public interface ICallReasonBusiness<T> where T : class
    {
        Task<GeneralResponse<T>> GetAll();
        //Task<IEnumerable<T>> Search(string name);
        Task<GeneralResponseSingleObject<T>> AddAsync(CallReason callReason);
        Task DeleteAsync(int id);
        Task<GeneralResponseSingleObject<T>> UpdateAsync(int id, CallReason callReason);
    }
}

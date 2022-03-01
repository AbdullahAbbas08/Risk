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
        Task AddAsync(InsertCallReasonDto callReason);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, CallReason callReason);
    }
}

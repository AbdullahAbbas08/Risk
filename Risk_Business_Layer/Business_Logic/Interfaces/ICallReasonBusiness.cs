using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.IRepositories.ICrud
{
    public interface ICallReasonBusiness<T> where T : class
    {
        Task<IEnumerable<T>> GetByIdAsync(int? id);
        //Task<IEnumerable<T>> Search(string name);
        Task AddAsync(CallReason callReason);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, CallReason callReason);
    }
}

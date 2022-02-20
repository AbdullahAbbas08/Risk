using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.IRepositories.ICrud
{
    public interface IGovernorateBusiness<T> where T : class
    {
        Task<IEnumerable<T>> GetByIdAsync(int? id);
        //Task<IEnumerable<T>> Search(string name);
        Task AddAsync(Governorate governorate);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Governorate governorate);
    }
}

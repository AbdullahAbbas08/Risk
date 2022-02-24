using Risk_Domain_Layer.DTO_S.ClientType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.IBusiness_Logic.Interfaces
{
    public interface IClientTypeBusiness<T> where T : class
    {
        Task<GeneralResponse<T>> GetAll(); 
        //Task<IEnumerable<T>> Search(string name);
        Task<GeneralResponseSingleObject<T>> AddAsync(AddClientTypeDto clientType);
        Task<GeneralResponseSingleObject<T>> DeleteAsync(int id);
        Task<GeneralResponseSingleObject<T>> UpdateAsync(int id, ClientType clientType);
    }
}
 
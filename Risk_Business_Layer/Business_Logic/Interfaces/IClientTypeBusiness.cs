using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Domain_Layer.DTO_S.ClientType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.IBusiness_Logic.Interfaces
{
    public interface IClientTypeBusiness<T>: ICrud<T> where T : class
    {
        Task<GeneralResponse<T>> GetAllClientType(int? id); 
        //Task<IEnumerable<T>> Search(string name);
        Task<GeneralResponseSingleObject<T>> AddClientType(AddClientTypeDto clientType);
        Task<GeneralResponseSingleObject<T>> DeleteClientType(int id);
        Task<GeneralResponseSingleObject<T>> UpdateClientType(int id, ClientType clientType);
    }
}
 
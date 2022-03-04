using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Domain_Layer.DTO_S.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.IRepositories.IClient
{
    public interface IClient: ICrud<Client>
    {
        Task<IEnumerable<GetClientDto>> GetAllWithRelatedTitles(); 
    }
}

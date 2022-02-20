using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Business_Layer.IUnitOfWork.IUnitOfWork_Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Repositories.Crud
{
    public class ClientTypeBusiness : IClientTypeBusiness<ClientType>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public ClientTypeBusiness(IUnitOfWork_Crud unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ClientType clientType)
        {
            try
            {
                if (clientType is not null)
                {
                    await unitOfWork.ClientType.Add(clientType);
                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var clientType = await unitOfWork.ClientType.Find(id);

                if (clientType != null)
                {
                    await unitOfWork.ClientType.Delete(id);
                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<IEnumerable<ClientType>> GetByIdAsync(int? id)
        {
            try
            {
                if (id is not null)
                {
                    var ClientType = await unitOfWork.ClientType.Find(c=>c.TypeId==id);

                    return ClientType;
                }
                else
                {
                    var ClientTypes = await unitOfWork.ClientType.GetAll();

                    return ClientTypes;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task UpdateAsync(int id, ClientType clientType)
        {
            try
            {
                if (id != 0 && clientType.TypeId == id)
                {
                    unitOfWork.ClientType.Update(clientType);
                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Business_Layer.IUnitOfWork.IUnitOfWork_Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Repositories.Crud
{
    public class GovernorateBusiness : IGovernorateBusiness<Governorate>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public GovernorateBusiness(IUnitOfWork_Crud unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Governorate governorate)
        {
            try
            {
                if (governorate is not null)
                {
                    await unitOfWork.Governorate.Add(governorate);
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
                var city = await unitOfWork.Governorate.Find(id);

                if (city != null)
                {
                    await unitOfWork.Governorate.Delete(id);
                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<IEnumerable<Governorate>> GetByIdAsync(int? id)
        {
            try
            {
                if (id is not null)
                {
                    var governorates = await unitOfWork.Governorate.Find(c=>c.Id==id);

                    return governorates;
                }
                else
                {
                    var governorates = await unitOfWork.Governorate.GetAll();

                    return governorates;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task UpdateAsync(int id, Governorate governorate)
        {
            try
            {
                if (id != 0 && governorate.Id == id)
                {
                    unitOfWork.Governorate.Update(governorate);
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

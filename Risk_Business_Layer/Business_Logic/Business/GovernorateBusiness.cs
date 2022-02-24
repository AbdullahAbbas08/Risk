using Risk_Business_Layer.IBusiness_Logic.Interfaces;
using Risk_Domain_Layer.DTO_S.Governorate;

namespace Risk_Business_Layer.Repositories.Crud
{
    public class GovernorateBusiness : IGovernorateBusiness<Governorate>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public GovernorateBusiness(IUnitOfWork_Crud unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Governorate> AddAsync(AddGovernorateDto governorate)
        {
            try
            {
                Governorate ReturnedGovernorate = new Governorate(); 
                if(!string.IsNullOrEmpty(governorate.Title))
                {
                    ReturnedGovernorate = await unitOfWork.Governorate.Add(new Governorate { Title = governorate.Title });
                    await unitOfWork.SaveChangesAsync();
                }   
                return ReturnedGovernorate;
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

        public async Task<IEnumerable<Governorate>> GetGovernorate()
        {
            try
            {
                var governorates = await unitOfWork.Governorate.GetAll();
                return governorates;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<Governorate> UpdateAsync(int id, AddGovernorateDto governorate)
        {
            try
            {
                var UpdatedObject = await unitOfWork.Governorate.Find(id);
                if (UpdatedObject != null)
                {
                    UpdatedObject.Title = governorate.Title;
                    await unitOfWork.SaveChangesAsync();
                }
                return UpdatedObject;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Risk_Business_Layer.IBusiness_Logic.Interfaces;
using Risk_Business_Layer.IUnitOfWork.IUnitOfWork_Crud;


namespace Risk_Business_Layer.Repositories.Crud
{
    public class CityBusiness : ICityBusiness<City>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public CityBusiness(IUnitOfWork_Crud unitOfWork )
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<City> AddAsync(City city)
        {
            try
            {
                City city1 = new City();
                if (city is not null)
                {
                    city1 =  await unitOfWork.City.Add(city);
                    await unitOfWork.SaveChangesAsync();
                }
                return city1;
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
                var city = await unitOfWork.City.Find(id);

                if (city != null)
                {
                    await unitOfWork.City.Delete(id);
                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            try
            {
                return await unitOfWork.City.GetAll();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GeneralResponseSingleObject<City>> UpdateAsync(int id, City model)
        {
            try
            {
                GeneralResponseSingleObject<City> response = new GeneralResponseSingleObject<City>();
                var governorate =await unitOfWork.Governorate.Find(model.GovernorateId);
                if (governorate == null)
                    response.Message = "كود المحافظة غير موجود أو غير صحيح";
                else
                {
                    var city = await unitOfWork.City.Find(id);
                    if (city != null)
                    {
                        model.Id = id;
                        city.Title = model.Title;
                        city.GovernorateId = model.GovernorateId;
                        response.Data = city;
                        await unitOfWork.SaveChangesAsync();
                        response.Message = "تمت عملية التعديل بنجاح";
                    }
                    else
                        response.Message = "كود المدينة غير موجود أو غير صحيح";
                }
                return response;

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

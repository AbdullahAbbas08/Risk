using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Business_Layer.IUnitOfWork.IUnitOfWork_Crud;


namespace Risk_Business_Layer.Repositories.Crud
{
    public class CityBusiness : ICityBusiness<City>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public CityBusiness(IUnitOfWork_Crud unitOfWork)
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

        public async Task UpdateAsync(int id, City city)
        {
            try
            {
                if (id != 0 && city.Id == id)
                {
                    unitOfWork.City.Update(city);
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

using Risk_Business_Layer.IRepositories.ICrud;
namespace Risk_Business_Layer.IRepositories.IClient
{
    public interface ICityRepo: ICrud<City>
    {
        Task<GeneralResponse<City>> GetCitiesWithGovernorate();
       
    }
}
 
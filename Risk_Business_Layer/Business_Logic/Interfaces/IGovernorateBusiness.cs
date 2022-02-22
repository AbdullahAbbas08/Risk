using Risk_Domain_Layer.DTO_S.Governorate;

namespace Risk_Business_Layer.IRepositories.ICrud
{
    public interface IGovernorateBusiness<T> where T : class
    {
        Task<IEnumerable<T>> GetGovernorate(); 
        //Task<IEnumerable<T>> Search(string name);
        Task<T> AddAsync(AddGovernorateDto governorate);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Governorate governorate);
    }
}

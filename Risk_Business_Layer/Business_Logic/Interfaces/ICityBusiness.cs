namespace Risk_Business_Layer.IBusiness_Logic.Interfaces
{
    public interface ICityBusiness<T> where T : class
    {
        Task<IEnumerable<T>> GetCities();
        //Task<IEnumerable<T>> Search(string name); 
        Task<T> AddAsync(City city);
        Task DeleteAsync(int id);
        Task<GeneralResponseSingleObject<T>> UpdateAsync(int id, City city);
    }
}

namespace Risk_Business_Layer.IRepositories.ICrud
{
    public interface ICityBusiness<T> where T : class
    {
        Task<IEnumerable<T>> GetCities();
        //Task<IEnumerable<T>> Search(string name); 
        Task<T> AddAsync(City city);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, City city);
    }
}

namespace Risk_Business_Layer.IBusiness_Logic.Interfaces
{
    public interface ISourceMarketingBusiness<T> where T : class
    {
        Task<IEnumerable<T>> GetByIdAsync(int? id);
        //Task<IEnumerable<T>> Search(string name);
        Task AddAsync(SourceMarketing sourceMarketing);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, SourceMarketing sourceMarketing);
    }
}

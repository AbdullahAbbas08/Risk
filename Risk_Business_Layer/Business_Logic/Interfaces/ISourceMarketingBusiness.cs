namespace Risk_Business_Layer.IBusiness_Logic.Interfaces
{
    public interface ISourceMarketingBusiness<T> where T : class
    {
        Task<GeneralResponse<T>> GetAll();
        //Task<IEnumerable<T>> Search(string name);
        Task<GeneralResponseSingleObject<T>> AddAsync(SourceMarketing sourceMarketing);
        Task DeleteAsync(int id);
        Task<GeneralResponseSingleObject<T>> UpdateAsync(int id, SourceMarketing sourceMarketing);
    }
}

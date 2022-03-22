namespace Risk_Business_Layer.IBusiness_Logic.Interfaces
{
    public interface ICallBusiness<T> where T : class
    {
        Task<GeneralResponse<T>> GetAll();
        //Task<IEnumerable<T>> Search(string name);
        Task<GeneralResponseSingleObject<T>> AddAsync(T callReason);
        Task DeleteAsync(int id);
        //Task<GeneralResponseSingleObject<T>> UpdateAsync(int id, CallReason callReason);
    }
}
  
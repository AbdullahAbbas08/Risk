using Risk_Business_Layer.IRepositories.ICrud;

namespace Risk_Business_Layer.IRepositories.ICustomer
{
    public interface ICustomer:ICrud<CustomerPhones>
    {
        Task<string> AddRange( List<(string,string)> CustomerPhones );
    }
}
 
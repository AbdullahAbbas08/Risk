using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Business_Layer.IRepositories.IClient;
using Risk_Business_Layer.IRepositories.ICrud; 

namespace Risk_Business_Layer.IUnitOfWork.IUnitOfWork_Crud
{
    public interface IUnitOfWork_Crud
    {
        ICrud<CallReason> CallReason { get; }
        ICrud<City> City { get;  }
        ICrud<Governorate> Governorate { get; }
        ICrud<ClientType> ClientType { get; }
        ICrud<Client> Client { get;  }
        ICrud<Customer> Customer { get;  }
        ICrud<AgentClient> AgentClient { get;  }
        ICrud<Employee> Employee { get;  }
        ICrud<SourceMarketing> SourceMarketing  { get; }
        ICrud<ClientCustomerServise> ClientCustomerServise { get; }
        ICrud<CallReasonClientType> CallReasonClientType { get; }
        ICrud<CustomerPhones> CustomerPhones  { get; }
        IClient client { get; }
        Task SaveChangesAsync(); 
    } 
}  

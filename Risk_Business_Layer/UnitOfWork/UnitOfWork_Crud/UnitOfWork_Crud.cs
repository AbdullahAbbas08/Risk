using Risk_Business_Layer.IRepositories.IClient;
using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Business_Layer.Repositories.Crud;
using Risk_Data_Access_Layer;

namespace Risk_Business_Layer.UnitOfWork.UnitOfWork_Crud
{
    public class UnitOfWork_Crud : IUnitOfWork_Crud
    {
        private readonly RiskDbContext riskDbContext;

        public UnitOfWork_Crud(RiskDbContext riskDbContext){ this.riskDbContext = riskDbContext; }

        private ICrud<CallReason> _CallReason; 
        public ICrud<CallReason> CallReason  {get {if(_CallReason == null){ _CallReason = new Crud<CallReason>(riskDbContext);}return _CallReason; } }
        
        private ICrud<Call> _Call; 
        public ICrud<Call> Call  {get {if(_Call == null){ _Call = new Crud<Call>(riskDbContext);}return _Call; } }


        private ICrud<City> _City;
        public ICrud<City> City  {get {  if(_City == null) { _City = new Crud<City>(riskDbContext); } return _City; }}


        private ICrud<Governorate> _Governorate; 
        public ICrud<Governorate> Governorate { get { if (_Governorate == null) { _Governorate = new Crud<Governorate>(riskDbContext); }return _Governorate; } }


        private ICrud<ClientType> _ClientType; 
        public ICrud<ClientType> ClientType { get { if (_ClientType == null) { _ClientType = new Crud<ClientType>(riskDbContext); }return _ClientType; } }

        private ICrud<Client> _Client;
        public ICrud<Client> Client { get { if (_Client == null) { _Client = new Crud<Client>(riskDbContext); }return _Client; } }


        private ICrud<Employee> _Employee; 
        public ICrud<Employee> Employee { get { if (_Employee == null) { _Employee = new Crud<Employee>(riskDbContext); } return _Employee; } }


        private ICrud<SourceMarketing> _SourceMarketing;
        public ICrud<SourceMarketing> SourceMarketing { get { if (_SourceMarketing == null) { _SourceMarketing = new Crud<SourceMarketing>(riskDbContext); }return _SourceMarketing; } }

        private IClient _client ;
        public IClient client { get { if (_client == null) { _client = new Risk_Business_Layer.Repositories.Client.Client(riskDbContext); } return _client; } }

        private ICrud<ClientCustomerServise> _ClientCustomerServise;
        public ICrud<ClientCustomerServise> ClientCustomerServise { get { if (_ClientCustomerServise == null) { _ClientCustomerServise = new Crud<ClientCustomerServise>(riskDbContext); } return _ClientCustomerServise; } } 
        
        private ICrud<Customer> _Customer;
        public ICrud<Customer> Customer { get { if (_Customer == null) { _Customer = new Crud<Customer>(riskDbContext); } return _Customer; } }
        
        private ICrud<CallReasonClientType> _CallReasonClientType;
        public ICrud<CallReasonClientType> CallReasonClientType { get { if (_CallReasonClientType == null) { _CallReasonClientType = new Crud<CallReasonClientType>(riskDbContext); } return _CallReasonClientType; } }
        
        private ICrud<CustomerPhones> _CustomerPhones;
        public ICrud<CustomerPhones> CustomerPhones { get { if (_CustomerPhones == null) { _CustomerPhones = new Crud<CustomerPhones>(riskDbContext); } return _CustomerPhones; } }

        public async Task SaveChangesAsync()
        {
           await riskDbContext.SaveChangesAsync();   
        }
    }
}

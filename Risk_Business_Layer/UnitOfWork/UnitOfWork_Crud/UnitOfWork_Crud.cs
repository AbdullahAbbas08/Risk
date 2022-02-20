using Risk_Business_Layer.IUnitOfWork.ICrud;
using Risk_Business_Layer.IUnitOfWork.IUnitOfWork_Crud;
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

        public async Task SaveChangesAsync()
        {
           await riskDbContext.SaveChangesAsync();   
        }
    }
}

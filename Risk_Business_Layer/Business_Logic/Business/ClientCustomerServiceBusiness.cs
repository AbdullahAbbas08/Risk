using Risk_Business_Layer.Business_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class ClientCustomerServiceBusiness : IClientCustomerServiceBusiness
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public ClientCustomerServiceBusiness(IUnitOfWork_Crud unitOfWork)
        {
            this.unitOfWork = unitOfWork; 
        }

        public async Task<GeneralResponseSingleObject<List<ClientCustomerServise>>> AddAsync(List<ClientCustomerServise> model)
        {
            var Clients=model.Select(x=>x.ClientId);
            var Customers = model.Select(x=>x.CustomerId);


            var ClientId = await unitOfWork.Client.Find(x => Clients.Contains(x.Id));
            var CustomerService = await unitOfWork.Employee.Find(x => Customers.Contains(x.Id));


            var ClientsFound  = (Clients.Except(ClientId.Select(x=>x.Id))).ToList();
            var CustomerFound  = (Customers.Except(CustomerService.Select(x=>x.Id))).ToList();


            if (!(ClientsFound.Count() == 0 || CustomerFound.Count() == 0))
                return new GeneralResponseSingleObject<List<ClientCustomerServise>> { Message = "ClientId Or CustomerService InCorrect " };
           
            GeneralResponseSingleObject<List<ClientCustomerServise>> response = new GeneralResponseSingleObject<List<ClientCustomerServise>>();
            response.Data = await unitOfWork.ClientCustomerServise.AddRange(model);
            await unitOfWork.SaveChangesAsync();
            response.Message = "Inserted Successfully";
             
            return response; 
        }
    }
}

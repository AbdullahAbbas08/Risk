using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Business_Layer.IRepositories.ICustomerService;
using Risk_Domain_Layer.DTO_S.Client;
using Risk_Domain_Layer.DTO_S.ClientCustomerService;
using Risk_Domain_Layer.DTO_S.Employee;
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
        private readonly ICustomerService customerService;

        public ClientCustomerServiceBusiness(IUnitOfWork_Crud unitOfWork, ICustomerService customerService)
        {
            this.unitOfWork = unitOfWork;
            this.customerService = customerService;
        }

        public async Task<GeneralResponseSingleObject<List<ClientCustomerServise>>> AddAsync(List<ClientCustomer> model)
        {
            try
            {
                var Clients = model.Select(x => x.ClientId);
                var Customers = model.Select(x => x.CustomerId);


                var ClientId = await unitOfWork.Client.Find(x => Clients.Contains(x.Id));
                var CustomerService = await unitOfWork.Employee.Find(x => Customers.Contains(x.Id));


                var ClientsFound = (Clients.Except(ClientId.Select(x => x.Id))).ToList();
                var CustomerFound = (Customers.Except(CustomerService.Select(x => x.Id))).ToList();


                if (!(ClientsFound.Count() == 0 || CustomerFound.Count() == 0))
                    return new GeneralResponseSingleObject<List<ClientCustomerServise>> { Message = "ClientId Or CustomerService InCorrect " };

                GeneralResponseSingleObject<List<ClientCustomerServise>> response = new GeneralResponseSingleObject<List<ClientCustomerServise>>();
                List<ClientCustomerServise> list = new List<ClientCustomerServise>();
                foreach (var item in model)
                {
                    list.Add(new ClientCustomerServise { ClientId = item.ClientId, CustomerId = item.CustomerId });
                }
                await customerService.AddRange(list);
                //response.Data = await unitOfWork.ClientCustomerServise.AddRange(model);
                //await unitOfWork.SaveChangesAsync();
                response.Message = "Inserted Successfully";

                return response;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
           
        }

        public async Task<GeneralResponse<GetEmployeeDto>> GetAllAgentRelatedWithOneClient(string Id)
        {
            var CustomerSeriveClient = (await unitOfWork.ClientCustomerServise.Find(x => x.ClientId == Id )).Select(x=>x.CustomerId).ToList();
            var CustomerService = (await unitOfWork.Employee.Find(x=> CustomerSeriveClient.Contains(x.Id))).ToList();

            GeneralResponse<GetEmployeeDto> res = new GeneralResponse<GetEmployeeDto>();
            List< GetEmployeeDto > List = new List< GetEmployeeDto >();
            foreach (var agent in CustomerService)
            {
                List.Add(new GetEmployeeDto
                {
                    Name = agent.Name,
                    Address = agent.Address,
                    ID = agent.Id,
                    Mobile = agent.Mobile,
                    NationalId = agent.NationalId,
                });
            }
            res.Data = List;

            return res;
        }
    }
}

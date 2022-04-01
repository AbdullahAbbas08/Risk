using Risk_Business_Layer.IBusiness_Logic.Interfaces;
using Risk_Data_Access_Layer;
using Risk_Domain_Layer.DTO_S.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class AdminBusiness : IAdminBusiness
    {
        private readonly RiskDbContext riskDbContext;

        public AdminBusiness(RiskDbContext riskDbContext)
        {
            this.riskDbContext = riskDbContext;
        }

        public async Task<GeneralResponse<ClientCallSearchResultReportDto>> ClientCallReport(ClientCallSearchInputReportDto model)
        {
            try
            {
                GeneralResponse<ClientCallSearchResultReportDto> generalResponse = new GeneralResponse<ClientCallSearchResultReportDto>();

                var Clients = (from item in riskDbContext.Clients
                               where (item.Name == model.ClientName || model.ClientName == null) &&
                                     (item.Mobile == model.Mobile || model.Mobile == null) &&
                                     (item.ClientTypeId == model.ClientType || model.ClientType == null)
                               select item).ToList();

                var AgentClient = (from item in riskDbContext.ClientCustomerServise
                                   select item).ToList();

                var Roles_Agent = (from item in riskDbContext.Roles
                                   where item.Name == Risk_Data_Access_Layer.Constants.Roles.Agent.ToString()
                                   select item.Id).ToList();

                var CustomerService_id = (from item in riskDbContext.UserRoles
                                          where Roles_Agent.Contains(item.RoleId)
                                          select item.UserId).ToList();


                var CustomerService = (from item in riskDbContext.employees
                                       where CustomerService_id.Contains(item.Id)
                                       select item).ToList();

                var Roles_Customer = (from item in riskDbContext.Roles
                                      where item.Name == Risk_Data_Access_Layer.Constants.Roles.Customer.ToString()
                                      select item.Id).ToList();



                var Customers_id = (from item in riskDbContext.UserRoles
                                    where Roles_Customer.Contains(item.RoleId)
                                    select item.UserId).ToList();



                var Customers = (from item in riskDbContext.Customers
                                 where Customers_id.Contains(item.Id)
                                 select item).ToList();


                var Governorate = (from item in riskDbContext.governorates
                                   where item.Id == model.Governorate || model.Governorate == null
                                   select item).ToList();

                var Cities = riskDbContext.cities.ToList();


                var CallReason = (from item in riskDbContext.CallReasons
                                  where item.Id == model.CallReasons || model.CallReasons == null
                                  select item).ToList();

                var Calls = (from item in riskDbContext.Call
                             where (item.Start >= model.CallDateFrom || model.CallDateFrom == null) &&
                                    (item.End <= model.CallDateTo || model.CallDateTo == null)
                             select item).ToList();

                var Query = (from call in Calls
                             join callreason in CallReason on call.CallReasonId equals callreason.Id
                             join customer in Customers on call.customerId equals customer.Id
                             join client in Clients on customer.ClientId equals client.Id
                             join city in Cities on customer.CityId equals city.Id
                             join govern in Governorate on city.GovernorateId equals govern.Id
                             join clientAgent in AgentClient on client.Id equals clientAgent.ClientId
                             join agent in CustomerService on clientAgent.CustomerId equals agent.Id
                             select new ClientCallSearchResultReportDto
                             {
                                 AgentName = agent.Name,
                                 CallType = call.CallType,
                                 CustomerName = customer.Name,
                                 MobileNumber = customer.Mobile,
                                 Gender = customer.Gender,
                                 Satisfy = call.Satisfy,
                                 Address= customer.Address,
                                 CallDescription = call.Description,
                                 CallEnd = call.End,
                                 CallStart = call.Start,
                                 CityName = city.Title,
                                 DOB = customer.DateOfBirth,
                                 mobile = agent.Mobile,
                                 Notes = call.Notes,
                             }).ToList();

                generalResponse.Data = Query;
                generalResponse.Message = "Success";
                return generalResponse;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

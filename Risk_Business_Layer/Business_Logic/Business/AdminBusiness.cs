using Elasticsearch.Net;
using Risk_Business_Layer.IBusiness_Logic.Interfaces;
using Risk_Data_Access_Layer;
using Risk_Data_Access_Layer.Constants;
using Risk_Domain_Layer.DTO_S.Admin;
using Risk_Domain_Layer.DTO_S.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class AdminBusiness : IAdminBusiness
    {
        private readonly RiskDbContext riskDbContext;

        public AdminBusiness(RiskDbContext riskDbContext)
        {
            this.riskDbContext = riskDbContext;
        }

        public async Task<List<AgentReportResponseSP>> Agent_Report(int flag)
        {
            if(flag == 1)
            {
                var Query = riskDbContext.AgentReportResponseSP.FromSqlInterpolated($"EXEC AgentReportSP;").ToList();
                return Query;
            }
            
            else if(flag == 2)
            {
                var Query = riskDbContext.AgentReportResponseSP.FromSqlInterpolated($"EXEC AgentReportMonthlySP;").ToList();
                return Query;
            } 
            
            else if(flag == 3)
            {
                var Query = riskDbContext.AgentReportResponseSP.FromSqlInterpolated($"EXEC AgentReportYearlySP;").ToList();
                return Query;
            } 
            
            else
            {
                var Query = riskDbContext.AgentReportResponseSP.FromSqlInterpolated($"EXEC AgentReportOverallSP;").ToList();
                return Query;
            }

           
        }
        
        public async Task<List<CallReasonReportResponseSP>> CallReason_Report(int flag)
        {
            if(flag == 1)
            {
                var Query = riskDbContext.CallReasonReportResponseSP.FromSqlInterpolated($"EXEC CallReasonReportdailySP;").ToList();
                return Query;
            }
            
            else if(flag == 2)
            {
                var Query = riskDbContext.CallReasonReportResponseSP.FromSqlInterpolated($"EXEC CallReasonReportMonthlySP;").ToList();
                return Query;
            } 
            
            else if(flag == 3)
            {
                var Query = riskDbContext.CallReasonReportResponseSP.FromSqlInterpolated($"EXEC CallReasonReportyearlySP;").ToList();
                return Query;
            } 
            
            else
            {
                var Query = riskDbContext.CallReasonReportResponseSP.FromSqlInterpolated($"EXEC CallReasonReportoverallSP;").ToList();
                return Query;
            }

           
        }

        public async Task<GeneralResponse<ClientCallSearchResultReportDto>> Call_Start_End_Report(CallStart_End_Report_Dto model)
        {
            try
            {

                GeneralResponse<ClientCallSearchResultReportDto> generalResponse = new GeneralResponse<ClientCallSearchResultReportDto>();

                var Clients = (from item in riskDbContext.Clients
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
                                 select new CustomerDto
                                 {
                                     Id = item.Id,
                                     Address = item.Address,
                                     CityId = item.CityId,
                                     DOB = item.DateOfBirth,
                                     Gender = item.Gender,
                                     mobile = item.Mobile,
                                     Name = item.Name
                                 }).ToList();


                var Governorate = (from item in riskDbContext.governorates
                                   select item).ToList();

                var Cities = riskDbContext.cities.ToList();


                var CallReason = (from item in riskDbContext.CallReasons
                                  select item).ToList();

                var Calls = (from item in riskDbContext.Call
                             where (item.StartCall >= model.CallDateFrom || model.CallDateFrom == null) &&
                                    (item.EndCall <= model.CallDateTo || model.CallDateTo == null)
                             select item).ToList();

                var call_client_callreason = (from call in Calls
                                              join agent in CustomerService
                                              on call.CustomerServiceId equals agent.Id
                                              join callreason in CallReason
                                              on call.CallReasonId equals callreason.Id
                                              select new ClientCallSearchResultReportDto
                                              {
                                                  CallType = call.CallType,
                                                  Satisfy = call.Satisfy,
                                                  CallDescription = call.Description,
                                                  CallEnd = call.EndCall,
                                                  CallStart = call.StartCall,
                                                  Notes = call.Notes,
                                                  CallReasonId = callreason.Id,
                                                  AgentId = agent.Id,
                                                  AgentName = agent.Name,
                                                  CustomerId = call.customerId
                                              }).ToList();

                var client_agent = (from client in Clients
                                    join clientAgent in AgentClient on client.Id equals clientAgent.ClientId
                                    join agent in call_client_callreason on clientAgent.CustomerId equals agent.AgentId
                                    select new ClientCallSearchResultReportDto
                                    {
                                        AgentName = agent.AgentName,
                                        CallType = agent.CallType,
                                        Satisfy = agent.Satisfy,
                                        CallDescription = agent.CallDescription,
                                        CallEnd = agent.CallEnd,
                                        CallStart = agent.CallStart,
                                        mobile = agent.mobile,
                                        Notes = agent.Notes,
                                        CallReasonId = agent.CallReasonId,
                                        AgentId = agent.AgentId,
                                        CustomerId = agent.CustomerId
                                    }).ToList();


                var Query = (from clientagent in client_agent
                             join customer in Customers on clientagent.CustomerId equals customer.Id
                             join city in Cities on customer.CityId equals city.Id
                             join govern in Governorate on city.GovernorateId equals govern.Id


                             select new ClientCallSearchResultReportDto
                             {
                                 AgentName = clientagent.AgentName,
                                 CallType = clientagent.CallType,
                                 CustomerName = customer.Name,
                                 MobileNumber = customer.mobile,
                                 Gender = customer.Gender,
                                 Satisfy = clientagent.Satisfy,
                                 Address = customer.Address,
                                 CallDescription = clientagent.CallDescription,
                                 CallEnd = clientagent.CallEnd,
                                 Duration = clientagent.CallEnd.TimeOfDay - clientagent.CallStart.TimeOfDay,
                                 CallStart = clientagent.CallStart,
                                 GovernorateId = govern.Id,
                                 GovernorateTitle = govern.Title,
                                 CityName = city.Title,
                                 CityId = city.Id,
                                 DOB = customer.DOB,
                                 mobile = clientagent.mobile,
                                 Notes = clientagent.Notes,
                                 CallReasonId = clientagent.CallReasonId,
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

        public async Task<GeneralResponse<ClientCallSearchResultReportDto>> ClientCallReport(ClientCallSearchInputReportDto model)
        {
            try
            {
                if (model.ClientType == -1)
                    model.ClientType = null;

                if (model.City == -1)
                    model.City = null;

                if (model.CallReasons == -1)
                    model.CallReasons = null;

                if (model.ClientName == "")
                    model.ClientName = null;

                if (model.Mobile == "")
                    model.Mobile = null;

                if (model.Governorate == -1)
                    model.Governorate = null;

                GeneralResponse<ClientCallSearchResultReportDto> generalResponse = new GeneralResponse<ClientCallSearchResultReportDto>();

                var Clients = (from item in riskDbContext.Clients
                               where (item.Name.Contains(model.ClientName) || model.ClientName == null) &&
                                     (item.Mobile.Contains(model.Mobile) || model.Mobile == null) &&
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

                var Cities = riskDbContext.cities.Where(x => x.Id == model.City || model.City == null).ToList();


                var CallReason = (from item in riskDbContext.CallReasons
                                  where item.Id == model.CallReasons || model.CallReasons == null
                                  select item).ToList();

                var Calls = (from item in riskDbContext.Call
                             where (item.StartCall >= model.CallDateFrom || model.CallDateFrom == null) &&
                                    (item.EndCall <= model.CallDateTo || model.CallDateTo == null)
                             select item).ToList();

                var call_client_callreason = (from call in Calls
                                              join agent in CustomerService
                                              on call.CustomerServiceId equals agent.Id
                                              join callreason in CallReason
                                              on call.CallReasonId equals callreason.Id
                                              select new ClientCallSearchResultReportDto
                                              {
                                                  CallType = call.CallType,
                                                  Satisfy = call.Satisfy,
                                                  CallDescription = call.Description,
                                                  CallEnd = call.EndCall,
                                                  CallStart = call.StartCall,
                                                  Notes = call.Notes,
                                                  CallReasonId = callreason.Id,
                                                  AgentId = agent.Id,
                                                  AgentName = agent.Name,
                                                  CustomerId = call.customerId
                                              }).ToList();

                var client_agent = (from client in Clients
                                    join clientAgent in AgentClient on client.Id equals clientAgent.ClientId
                                    join agent in call_client_callreason on clientAgent.CustomerId equals agent.AgentId
                                    select new ClientCallSearchResultReportDto
                                    {
                                        AgentName = agent.AgentName,
                                        CallType = agent.CallType,
                                        Satisfy = agent.Satisfy,
                                        CallDescription = agent.CallDescription,
                                        CallEnd = agent.CallEnd,
                                        CallStart = agent.CallStart,
                                        mobile = agent.mobile,
                                        Notes = agent.Notes,
                                        CallReasonId = agent.CallReasonId,
                                        AgentId = agent.AgentId,
                                        CustomerId = agent.CustomerId
                                    }).ToList();


                var Query = (from clientagent in client_agent
                             join customer in Customers on clientagent.CustomerId equals customer.Id
                             join city in Cities on customer.CityId equals city.Id
                             join govern in Governorate on city.GovernorateId equals govern.Id


                             select new ClientCallSearchResultReportDto
                             {
                                 AgentName = clientagent.AgentName,
                                 CallType = clientagent.CallType,
                                 CustomerName = customer.Name,
                                 MobileNumber = customer.Mobile,
                                 Gender = customer.Gender,
                                 Satisfy = clientagent.Satisfy,
                                 Address = customer.Address,
                                 CallDescription = clientagent.CallDescription,
                                 CallEnd = clientagent.CallEnd,
                                 CallStart = clientagent.CallStart,
                                 GovernorateId = govern.Id,
                                 GovernorateTitle = govern.Title,
                                 CityName = city.Title,
                                 CityId = city.Id,
                                 DOB = customer.DateOfBirth,
                                 mobile = clientagent.mobile,
                                 Notes = clientagent.Notes,
                                 CallReasonId = clientagent.CallReasonId,
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

        public async Task<GeneralResponse<Stats>> Stats_Report(int day, int month, int year)
        {
            DateTime date = new DateTime(year,month,day);
            DateTime DateToMonth = new DateTime(year,month,1);
            DateTime DateToYear = new DateTime(year,1,1);

            Stats Day = new Stats();
            List<Stats> StatList = new ();

            var CallSummery = (from item in riskDbContext.Call select item).ToList();

            Day.All = CallSummery.Where(x => x.CreationDate.Date == date).Count();
            Day.In  = CallSummery.Where(x => x.CreationDate.Date == date && x.CallType == CallType.In).Count();
            Day.Out = CallSummery.Where(x => x.CreationDate.Date == date && x.CallType == CallType.Out).Count();

            StatList.Add (Day);

            Stats Month = new Stats();
            Month.All = CallSummery.Where(x => x.CreationDate.Date <= DateTime.Now && x.CreationDate.Date >= DateToMonth).Count();
            Month.In  = CallSummery.Where(x => x.CreationDate.Date <= DateTime.Now && x.CreationDate.Date >= DateToMonth && x.CallType == CallType.In).Count();
            Month.Out = CallSummery.Where(x => x.CreationDate.Date <= DateTime.Now && x.CreationDate.Date >= DateToMonth && x.CallType == CallType.Out).Count();

            StatList.Add(Month);

            Stats Year = new Stats();
            Year.All = CallSummery.Where(x => x.CreationDate.Date <= DateTime.Now && x.CreationDate.Date >= DateToYear).Count();
            Year.In  = CallSummery.Where(x => x.CreationDate.Date <= DateTime.Now && x.CreationDate.Date >= DateToYear && x.CallType == CallType.In).Count();
            Year.Out = CallSummery.Where(x => x.CreationDate.Date <= DateTime.Now && x.CreationDate.Date >= DateToYear && x.CallType == CallType.Out).Count();

            StatList.Add(Year);

            return new GeneralResponse<Stats> { Data = StatList };

        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Risk_Business_Layer.IRepositories.IEmployee;
using Risk_Business_Layer.Repositories.Crud;
using Risk_Business_Layer.Services.AuthenticationModels;
using Risk_Data_Access_Layer;
using Risk_Domain_Layer.DTO_S.Employee;

namespace Risk_Business_Layer.Repositories.EmployeeRepo
{
    public class EmployeeRepo : Crud<Employee>, IEmployeeRepo
    {
        private readonly RiskDbContext riskDbContext;


        public EmployeeRepo(RiskDbContext riskDbContext) : base(riskDbContext)
        {
            this.riskDbContext = riskDbContext;
        } 

        public GeneralResponseSingleObject<EmptyResponse> DeleteEmployee(string ID)
        {
            try
            {
                GeneralResponseSingleObject<EmptyResponse> response = new GeneralResponseSingleObject<EmptyResponse>();
                var entity = (from x in riskDbContext.employees
                              where x.Id == ID
                              select x).FirstOrDefault();

                if (entity != null)
                {
                    riskDbContext.employees.Remove(entity);
                    riskDbContext.Users.Remove(entity);
                    riskDbContext.SaveChanges();
                    response.Message = "تم حذف الموظف بنجاح";
                }
                else
                    response.Message = "هناك خطأ حاول مرة أخرى";

                return response;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

        public async Task<GeneralResponse<GetEmployeeDto>> GetAll()
        {
           
            var Employee = await riskDbContext.employees.Select(x =>
           new GetEmployeeDto
           {
               ID=x.Id,
              Address = x.Address,
              Mobile = x.Mobile,
              Name = x.Name,
              NationalId = x.NationalId,
              UserName=x.UserName, 
              password=x.PasswordHash
           }).ToListAsync();

            return new GeneralResponse<GetEmployeeDto> { Data=Employee,Message="Data returned Successfully"};
        } 

    }
}

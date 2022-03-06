using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Risk_Business_Layer.IRepositories.IEmployee;
using Risk_Business_Layer.Services;
using Risk_Business_Layer.Services.AuthenticationModels;
using Risk_Domain_Layer.DTO_S.Employee;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo Employee;
        private readonly IAuthService authService;

        public EmployeeController(IEmployeeRepo _Employee, IAuthService authService)
        {
            this.Employee = _Employee;
            this.authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralResponse<GetEmployeeDto>>> GetAll()
        {
            return await Employee.GetAll();
        }

        [HttpDelete("{id}")]
        public GeneralResponseSingleObject<EmptyResponse> Delete(string id)
        {
            try
            {
                return  Employee.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPut]
        public async Task<GeneralResponseSingleObject<UpdateEmployee>> Update(UpdateEmployee model)
        {
            try
            {
                return await authService.UpdateEmployee(model);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
  
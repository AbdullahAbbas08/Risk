using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Domain_Layer.DTO_S.CustomerService;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceController : ControllerBase
    {
        private readonly ICustomerServiceBusiness customerService;

        public CustomerServiceController(ICustomerServiceBusiness customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Addrange(InsertCustomerServ model)
        {
            try
            {
                await customerService.AddRange(new ClientCustomerService { ClientId = model.ClientId,CustomerServiseId=model.CustomerServiseId});
                return "success";
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
            }
        }
    }
}

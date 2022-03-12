using Risk_Business_Layer.Business_Logic.Interfaces;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceController : ControllerBase
    {
        private readonly ICustomerServiceBusiness customerService;
        private readonly IClientCustomerServiceBusiness clientCustomerServise;

        public CustomerServiceController(ICustomerServiceBusiness customerService , IClientCustomerServiceBusiness _ClientCustomerServise)
        {
            this.customerService = customerService;
            clientCustomerServise = _ClientCustomerServise;
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponseSingleObject<List<ClientCustomerServise>>>> InsertClientCustomerServise(List<ClientCustomerServise> model)
        {
            try
            {
                return await clientCustomerServise.AddAsync(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public GeneralResponse<ClientCustomerServise> GetCustomerRelatedWithAgent(string id)
        {
            return customerService.GetCustomerRelatedWithAgent(id);
        }

    }
}

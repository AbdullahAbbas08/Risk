using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Domain_Layer.DTO_S;
using Risk_Domain_Layer.DTO_S.Client;
using Risk_Domain_Layer.DTO_S.ClientCustomerService;

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
        public async Task<ActionResult<GeneralResponseSingleObject<List<ClientCustomerServise>>>> InsertClientCustomerServise(List<ClientCustomer> model)
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
        public GeneralResponse<ClientDto> GetCustomerRelatedWithAgent(string Toaken)
        {
            return customerService.GetCustomerRelatedWithAgent(Toaken);
        }
        
        [HttpGet("GetClientsRelatedWithAgent")]
        public GeneralResponse<IdNameList> GetClientsRelatedWithAgent(string AgentID)
        {
            return customerService.GetClientsRelatedWithAgent(AgentID);
        }

    }
}

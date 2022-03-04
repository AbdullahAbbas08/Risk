using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Domain_Layer.DTO_S.Client;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientBusiness clientBusiness;

        public ClientController(IClientBusiness clientBusiness)
        {
            this.clientBusiness = clientBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralResponse<GetClientDto>>> GetAll()
        {
            return await clientBusiness.GetAll();
        }
    }
}

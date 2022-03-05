using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Business_Layer.Services.Authentication;
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralResponseSingleObject<EmptyResponse>>> Delete(string id)
        {
            try
            {
                return await clientBusiness.DeleteClient(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult<GeneralResponseSingleObject<Client>>> Update([FromForm] UpdateClientModel model)
        {
            try
            {
                return await clientBusiness.UpdateClient(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
    }
}

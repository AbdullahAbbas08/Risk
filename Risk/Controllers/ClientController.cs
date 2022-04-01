using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Business_Layer.Services;
using Risk_Business_Layer.Services.Authentication;
using Risk_Domain_Layer.DTO_S;
using Risk_Domain_Layer.DTO_S.Client;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientBusiness clientBusiness;
        private readonly IAuthService authService;

        public ClientController(IClientBusiness clientBusiness, IAuthService authService)
        {
            this.clientBusiness = clientBusiness;
            this.authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralResponse<GetClientDto>>> GetAll()
        {
            return await clientBusiness.GetAll();
        }
        

        [HttpGet("FilterWithRelatedTitles")]
        public async Task<ActionResult<GeneralResponse<GetClientDto>>> FilterClientWithRelatedTitles(string? ClientName, string? Mobile, int? ClientType)
        {
            return await clientBusiness.FilterClientWithRelatedTitles(ClientName, Mobile,ClientType);
        } 
        
        [HttpGet("GetAllIdName")]
        public async Task<ActionResult<GeneralResponse<IdNameList>>> GetAllIdName()
        {
            return await clientBusiness.GetAllIdName();
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
        public async Task<ActionResult<GeneralResponseSingleObject<UpdateClientModel>>> Update([FromForm] UpdateClientDto model)
        {
            try
            {
                return await authService.UpdateClient(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

    }
}

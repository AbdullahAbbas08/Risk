using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Risk_Business_Layer.IRepositories.ICrud;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {

        private readonly IClientTypeBusiness<ClientType> clientTypeBusiness;

        public LookupController(IClientTypeBusiness<ClientType> clientTypeBusiness)
        {
            this.clientTypeBusiness = clientTypeBusiness;
        }

        /// <summary>
        /// get all Client Types 
        /// </summary>
        /// <returns>
        /// List of Client type
        /// </returns>
        // GET: api/ClientType/5
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ClientType>>> GetClientType()
        {
            try
            {
                var ClientTypes = await clientTypeBusiness.GetByIdAsync(null);

                if (ClientTypes == null)
                {
                    return NoContent();
                }

                return Ok(ClientTypes);

            }
            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }
    }
}

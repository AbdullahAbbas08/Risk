using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Risk_Business_Layer.IRepositories.ICrud;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientTypeController : ControllerBase
    {
        private readonly IClientTypeBusiness<ClientType> clientTypeBusiness;

        public ClientTypeController(IClientTypeBusiness<ClientType> clientTypeBusiness)
        {
            this.clientTypeBusiness = clientTypeBusiness;
        }

        /// <summary>
        /// Api for get all ClientTypes without parameter or a specific one if his id is entered
        /// </summary>
        /// <param name="id">ID for ClientType</param>
        /// <returns></returns>
        // GET: api/ClientType/5
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ClientType>>> GetClientType(int? id = null)
        {
            try
            {
                var ClientTypes = await clientTypeBusiness.GetByIdAsync(id);

                if (ClientTypes == null)
                {
                    return NoContent();
                }

                return Ok(ClientTypes);

            }
            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }


        /// <summary>
        /// Api for Update an existing ClientType
        /// </summary>
        /// <param name="id">ID for ClientType</param>
        /// <param name="clientType">Model for update</param>
        /// <returns></returns>
        // PUT: api/ClientType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientType(int id, ClientType clientType)
        {
            try
            {
                await clientTypeBusiness.UpdateAsync(id, clientType);

                return Ok("Updated Successfully");
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }

        /// <summary>
        /// API For Adding A New ClientType
        /// </summary>
        /// <param name="clientType">Model for add ClientType</param>
        /// <returns></returns>
        // POST: api/ClientType
        [HttpPost]
        public async Task<ActionResult<ClientType>> PostClientType(ClientType clientType)
        {
            try
            {
                await clientTypeBusiness.AddAsync(clientType);

                return Ok(clientType);
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }

        /// <summary>
        /// API For Delete An Existing ClientType
        /// </summary>
        /// <param name="id">ID for ClientType</param>
        /// <returns></returns>
        // DELETE: api/ClientType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                await clientTypeBusiness.DeleteAsync(id);

                return Ok();
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }
    }
}

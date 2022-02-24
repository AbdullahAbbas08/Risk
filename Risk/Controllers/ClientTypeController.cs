using Risk_Domain_Layer.DTO_S.ClientType;

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
        /// Insert New ClientType
        /// </summary>
        /// <param name="clientType">Model for add ClientType</param>
        /// <returns>
        /// Object TypeOf => ClientType that Inserted Successfully
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<GeneralResponseSingleObject<ClientType>>> PostClientType(AddClientTypeDto clientType)
        {
            try
            {
                return await clientTypeBusiness.AddAsync(clientType);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
            }

        }

        /// <summary>
        /// Api for get all ClientTypes without parameter 
        /// </summary>
        /// <returns></returns>
        // GET: api/ClientType/5
        [HttpGet]
        public async Task<ActionResult<GeneralResponse<ClientType>>> GetClientType()
        {
            try
            {
               return await clientTypeBusiness.GetAll();
               
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.InnerException); 
            }

        }


        /// <summary>
        /// Api for Update an existing ClientType
        /// </summary>
        /// <param name="id">ID for ClientType</param>
        /// <param name="clientType">Model for update</param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<ActionResult<GeneralResponseSingleObject<ClientType>>> PutClientType(int id, AddClientTypeDto model)
        {
            try
            {
               return await clientTypeBusiness.UpdateAsync(id, new ClientType { Title = model.Title});
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.InnerException);
            }
        }

       

        /// <summary>
        /// API For Delete An Existing ClientType
        /// </summary>
        /// <param name="id">ID for ClientType</param>
        /// <returns></returns>
        [HttpDelete("id")] 
        public async Task<ActionResult<GeneralResponseSingleObject<ClientType>>> DeleteCity(int id)
        {
            try
            {
              return  await clientTypeBusiness.DeleteAsync(id);
            }

            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.InnerException);
            }
        }
    }
}

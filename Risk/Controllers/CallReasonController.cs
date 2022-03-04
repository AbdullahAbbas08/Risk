using Risk_Domain_Layer.DTO_S.CallReason;

namespace Risk.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CallReasonController : ControllerBase
    {
        private readonly ICallReasonBusiness<CallReason> callReasonBusiness;

        public CallReasonController(ICallReasonBusiness<CallReason> callReasonBusiness)
        {
            this.callReasonBusiness = callReasonBusiness;
        }

        /// <summary>
        /// Api for get all CallReasons without parameter or a specific one if his id is entered
        /// </summary>
        /// <param name="id">ID for CallReason</param>
        /// <returns></returns>
        // GET: api/CallReason/5

        //[Authorize(Roles = Roles.Admin + "," + Roles.Agent)]
        [HttpGet]
        public async Task<ActionResult<GeneralResponse<CallReason>>> GetCallReason()
        {
            try
            {

                #region Generate Returned Object TypeOf GeneralResponse
                GeneralResponse<CallReason> GeneralResponse = new GeneralResponse<CallReason>();
                #endregion

                #region Call Service
                var callReasons = await callReasonBusiness.GetAll();
                #endregion

                #region return 
                GeneralResponse.Message = "Successffully";
                return Ok(GeneralResponse);
                #endregion
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        /// <summary>
        /// Api for Update an existing CallReason
        /// </summary>
        /// <param name="id">ID for CallReason</param>
        /// <param name="callReason">Model for update</param>
        /// <returns></returns>
        // PUT: api/CallReason/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GeneralResponseSingleObject<CallReason>>> PutCallReason(int id, InsertCallReasonDto model)
        {
            try
            {
                return await callReasonBusiness.UpdateAsync(id, new CallReason { Title = model.title, Order = model.order });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
            }

        }

        /// <summary>
        /// API For Adding A New CallReason
        /// </summary>
        /// <param name="service">Model for add CallReason</param>
        /// <returns></returns>
        // POST: api/Services
        [HttpPost]
        public async Task<ActionResult<GeneralResponseSingleObject<CallReason>>> PostCallReason(InsertCallReasonDto model)
        {
            try
            {
                return await callReasonBusiness.AddAsync(new CallReason { Title = model.title, Order = model.order });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
            }
        }

        /// <summary>
        /// API For Delete An Existing CallReason
        /// </summary>
        /// <param name="id">ID for CallReason</param>
        /// <returns></returns>
        // DELETE: api/CallReason/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCallReason(int id)
        {
            try
            {
                await callReasonBusiness.DeleteAsync(id);

                return Ok();
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Risk_Business_Layer.Constants;
using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Data_Access_Layer.Constants;

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
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CallReason>>> GetCallReason(int? id = null)
        {
            try
            {
                var callReasons = await callReasonBusiness.GetByIdAsync(id);

                if (callReasons == null)
                {
                    return NoContent();
                }

                return Ok(callReasons);

            }
            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }


        /// <summary>
        /// Api for Update an existing CallReason
        /// </summary>
        /// <param name="id">ID for CallReason</param>
        /// <param name="callReason">Model for update</param>
        /// <returns></returns>
        // PUT: api/CallReason/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCallReason(int id, CallReason callReason)
        {
            try
            {
                await callReasonBusiness.UpdateAsync(id, callReason);

                return Ok("Updated Successfully");
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }

        /// <summary>
        /// API For Adding A New CallReason
        /// </summary>
        /// <param name="service">Model for add CallReason</param>
        /// <returns></returns>
        // POST: api/Services
        [HttpPost]
        public async Task<ActionResult<CallReason>> PostCallReason(CallReason callReason)
        {
            try
            {
                await callReasonBusiness.AddAsync(callReason);

                return Ok(callReason);
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

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

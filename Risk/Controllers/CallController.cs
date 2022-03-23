using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Domain_Layer.DTO_S.Call;
using Risk_Domain_Layer.DTO_S.CallReason;

namespace Risk.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly ICallBusiness<Call> callBusiness;

        public CallController(ICallBusiness<Call> callBusiness )
        {
            this.callBusiness = callBusiness;
        }

        /// <summary>
        /// Api for get all CallReasons without parameter or a specific one if his id is entered
        /// </summary>
        /// <param name="id">ID for CallReason</param>
        /// <returns></returns>
        // GET: api/CallReason/5

        //[Authorize(Roles = Roles.Admin + "," + Roles.Agent)]
        [HttpGet]
        public async Task<ActionResult<GeneralResponse<Call>>> GetCall()
        {
            try
            {

                #region Generate Returned Object TypeOf GeneralResponse
                GeneralResponse<Call> GeneralResponse = new GeneralResponse<Call>();
                #endregion

                #region Call Service
               GeneralResponse = await callBusiness.GetAll();
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
        //[HttpPut("{id}")]
        //public async Task<ActionResult<GeneralResponseSingleObject<Call>>> PutCallReason(int id, InsertCallDto model)
        //{
        //    try
        //    {
        //        return await callBusiness.UpdateAsync(id, new Call { Title = model.title, Order = model.order });
        //    }

        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
        //    }

        //}

        /// <summary>
        /// API For Adding A New CallReason
        /// </summary>
        /// <param name="service">Model for add CallReason</param>
        /// <returns></returns>
        // POST: api/Services 
        [HttpPost]
        public async Task<ActionResult<GeneralResponseSingleObject<Call>>> PostCall(InsertCallDto model)
        {
            try
            {
                return await callBusiness.AddAsync(new Call {
                    CallReasonId =model.CallReasonId,
                    SourceMarketId = model.SourceMarketId,
                    Start = model.Start,
                    End = model.End,
                    Description = model.Description,
                    Notes = model.Notes,
                    CallType = model.CallType,
                    Reason = model.Reason,
                    Satisfy = model.Satisfy ,
                    customerId = model.customerId
                    });
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
        public async Task<IActionResult> DeleteCall(int id)
        {
            try
            {
                await callBusiness.DeleteAsync(id);

                return Ok();
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }
    }
}

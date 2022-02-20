using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Risk_Business_Layer.IRepositories.ICrud;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceMarketingController : ControllerBase
    {
        private readonly ISourceMarketingBusiness<SourceMarketing> sourceMarketingBusiness;

        public SourceMarketingController(ISourceMarketingBusiness<SourceMarketing> sourceMarketingBusiness)
        {
            this.sourceMarketingBusiness = sourceMarketingBusiness;
        }

        /// <summary>
        /// Api for get all SourceMarketings without parameter or a specific one if his id is entered
        /// </summary>
        /// <param name="id">ID for SourceMarketing</param>
        /// <returns></returns>
        // GET: api/SourceMarketing/5
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<SourceMarketing>>> GetSourceMarketing(int? id = null)
        {
            try
            {
                var SourceMarketings = await sourceMarketingBusiness.GetByIdAsync(id);

                if (SourceMarketings == null)
                {
                    return NoContent();
                }

                return Ok(SourceMarketings);

            }
            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }


        /// <summary>
        /// Api for Update an existing SourceMarketing
        /// </summary>
        /// <param name="id">ID for SourceMarketing</param>
        /// <param name="city">Model for update</param>
        /// <returns></returns>
        // PUT: api/SourceMarketing/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSourceMarketing(int id, SourceMarketing SourceMarketing)
        {
            try
            {
                await sourceMarketingBusiness.UpdateAsync(id, SourceMarketing);

                return Ok("Updated Successfully");
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }

        /// <summary>
        /// API For Adding A New SourceMarketing
        /// </summary>
        /// <param name="SourceMarketing">Model for add SourceMarketing</param>
        /// <returns></returns>
        // POST: api/SourceMarketing
        [HttpPost]
        public async Task<ActionResult<SourceMarketing>> PostSourceMarketing(SourceMarketing SourceMarketing)
        {
            try
            {
                await sourceMarketingBusiness.AddAsync(SourceMarketing);

                return Ok(SourceMarketing);
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }

        /// <summary>
        /// API For Delete An Existing SourceMarketing
        /// </summary>
        /// <param name="id">ID for SourceMarketing</param>
        /// <returns></returns>
        // DELETE: api/SourceMarketing/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSourceMarketing(int id)
        {
            try
            {
                await sourceMarketingBusiness.DeleteAsync(id);

                return Ok();
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }
    }
}

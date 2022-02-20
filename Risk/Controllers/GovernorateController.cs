using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Risk_Business_Layer.IRepositories.ICrud;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernorateController : ControllerBase
    {
        private readonly IGovernorateBusiness<Governorate> governorateBusiness;

        public GovernorateController(IGovernorateBusiness<Governorate> governorateBusiness)
        {
            this.governorateBusiness = governorateBusiness;
        }

        /// <summary>
        /// Api for get all Governorates without parameter or a specific one if his id is entered
        /// </summary>
        /// <param name="id">ID for governorate</param>
        /// <returns></returns>
        // GET: api/Governorate/5
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Governorate>>> GetGovernorate(int? id = null)
        {
            try
            {
                var governorates = await governorateBusiness.GetByIdAsync(id);

                if (governorates == null)
                {
                    return NoContent();
                }

                return Ok(governorates);

            }
            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }


        /// <summary>
        /// Api for Update an existing Governorate
        /// </summary>
        /// <param name="id">ID for Governorate</param>
        /// <param name="city">Model for update</param>
        /// <returns></returns>
        // PUT: api/Governorate/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGovernorate(int id, Governorate governorate)
        {
            try
            {
                await governorateBusiness.UpdateAsync(id, governorate);

                return Ok("Updated Successfully");
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }

        /// <summary>
        /// API For Adding A New Governorate
        /// </summary>
        /// <param name="governorate">Model for add Governorate</param>
        /// <returns></returns>
        // POST: api/Governorate
        [HttpPost]
        public async Task<ActionResult<City>> PostGovernorate(Governorate governorate)
        {
            try
            {
                await governorateBusiness.AddAsync(governorate);

                return Ok(governorate);
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }

        /// <summary>
        /// API For Delete An Existing Governorate
        /// </summary>
        /// <param name="id">ID for Governorate</param>
        /// <returns></returns>
        // DELETE: api/Governorate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGovernorate(int id)
        {
            try
            {
                await governorateBusiness.DeleteAsync(id);

                return Ok();
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }
    }
}

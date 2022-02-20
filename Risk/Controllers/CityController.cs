using Risk_Business_Layer.IRepositories.ICrud;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityBusiness<City> cityBusiness;

        public CityController(ICityBusiness<City> cityBusiness)
        {
            this.cityBusiness = cityBusiness;
        }

        /// <summary>
        /// Api for get all Cities without parameter or a specific one if his id is entered
        /// </summary>
        /// <param name="id">ID for City</param>
        /// <returns></returns>
        // GET: api/City/5
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<City>>> GetCity(int? id = null)
        {
            try
            {
                var cities = await cityBusiness.GetByIdAsync(id);

                if (cities == null)
                {
                    return NoContent();
                }

                return Ok(cities);

            }
            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }


        /// <summary>
        /// Api for Update an existing City
        /// </summary>
        /// <param name="id">ID for CallReason</param>
        /// <param name="city">Model for update</param>
        /// <returns></returns>
        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            try
            {
                await cityBusiness.UpdateAsync(id, city);

                return Ok("Updated Successfully");
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }

        /// <summary>
        /// API For Adding A New City
        /// </summary>
        /// <param name="city">Model for add City</param>
        /// <returns></returns>
        // POST: api/City
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            try
            {
                await cityBusiness.AddAsync(city);

                return Ok(city);
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }

        /// <summary>
        /// API For Delete An Existing City
        /// </summary>
        /// <param name="id">ID for City</param>
        /// <returns></returns>
        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                await cityBusiness.DeleteAsync(id);

                return Ok();
            }

            catch (Exception ex) { return BadRequest(ex.InnerException); }

        }
    }
}

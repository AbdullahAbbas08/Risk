using Risk_Business_Layer.IRepositories.IClient;
using Risk_Domain_Layer.DTO_S.City;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityBusiness<City> cityBusiness;
        private readonly ICityRepo cityRepo;

        public CityController(ICityBusiness<City> cityBusiness , ICityRepo cityRepo)
        {
            this.cityBusiness = cityBusiness;
            this.cityRepo = cityRepo;
        }

        /// <summary>
        /// Api for get all Cities without parameter or a specific one if his id is entered
        /// </summary>
        /// <param name="id">ID for City</param>
        /// <returns></returns>
        // GET: api/City/5
        [HttpGet]
        public async Task<ActionResult<GeneralResponse<City>>> GetCity()
        {
            try
            {
                #region Generate Returned Object TypeOf GeneralResponse
                GeneralResponse<City> GeneralResponse = new GeneralResponse<City>();
                #endregion

                #region Call Service
                var cities = await cityBusiness.GetCities();
                GeneralResponse.Data = cities.ToList();
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
        
        
        [HttpGet("GetCitiesWithGovernorate")]
        public async Task<ActionResult<GeneralResponse<City>>> GetCitiesWithGovernorate()
        {
            try
            {
                #region Call Service
                return await cityRepo.GetCitiesWithGovernorate();
                #endregion
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Api for Update an existing City
        /// </summary>
        /// <param name="id">ID for CallReason</param>
        /// <param name="city">Model for update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<GeneralResponseSingleObject<City>>> PutCity(int id, AddCityDto model)
        {
            try
            {
                return await cityBusiness.UpdateAsync(id, new City {Title = model.CityName , GovernorateId = model.GovernorateID } );
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.InnerException);
            }
        }

        /// <summary>
        /// API For Adding A New City
        /// </summary>
        /// <param name="city">Model for add City</param>
        /// <returns></returns>
        // POST: api/City
        [HttpPost]
        public async Task<ActionResult<GeneralResponseSingleObject<City>>> PostCity(AddCityDto city)
        {
            try
            {
                #region Generate Returned Object TypeOf GeneralResponse
                GeneralResponseSingleObject<City> GeneralResponse = new GeneralResponseSingleObject<City>();
                #endregion

                #region Call Service
                GeneralResponse.Data =  await cityBusiness.AddAsync(new City { Title = city.CityName, GovernorateId = city.GovernorateID });
                #endregion

                #region return 
                GeneralResponse.Message = "City Added Successffully";
                return Ok(GeneralResponse);
                #endregion
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

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

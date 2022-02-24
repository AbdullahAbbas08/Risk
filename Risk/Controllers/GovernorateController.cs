using Risk_Domain_Layer.DTO_S.Governorate;

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
        /// <returns>
        /// List of Object type of Class => Governorate
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Governorate>>> GetGovernorate()
        {
            try
            {
                #region Generate Returned Object TypeOf GeneralResponse
                GeneralResponse<Governorate> GeneralResponse = new GeneralResponse<Governorate>();
                #endregion

                #region Call Service
                var Governorates = await governorateBusiness.GetGovernorate();
                GeneralResponse.Data = Governorates.ToList();
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
        /// Api for Update an existing Governorate
        /// </summary>
        /// <param name="id">ID for Governorate</param>
        /// <param name="city">Model for update</param>
        /// <returns></returns>
        // PUT: api/Governorate/5
        [HttpPut]
        public async Task<IActionResult> PutGovernorate(int id, AddGovernorateDto governorate)
        {

            #region Generate Returned Object TypeOf GeneralResponse
            GeneralResponseSingleObject<Governorate> GeneralResponse = new GeneralResponseSingleObject<Governorate>();
            #endregion

            #region Call Service
            GeneralResponse.Data = await governorateBusiness.UpdateAsync(id, new AddGovernorateDto { Title = governorate.Title });
            #endregion

            #region return 
            if (GeneralResponse.Data == null)
                GeneralResponse.Message = "Something wrong , try again";
            else
                GeneralResponse.Message = "governorate Updated Successffully";
            return Ok(GeneralResponse);
            #endregion

        }

        /// <summary>
        /// API For Adding A New Governorate
        /// </summary>
        /// <param name="governorate">Model for add Governorate</param>
        /// <returns></returns>
        // POST: api/Governorate
        [HttpPost]
        public async Task<ActionResult<GeneralResponseSingleObject<Governorate>>> PostGovernorate(AddGovernorateDto Governorate)
        {
            try
            {
                #region Generate Returned Object TypeOf GeneralResponse
                GeneralResponseSingleObject<Governorate> GeneralResponse = new GeneralResponseSingleObject<Governorate>();
                #endregion

                #region Call Service
                GeneralResponse.Data = await governorateBusiness.AddAsync(Governorate);
                #endregion

                #region return 
                GeneralResponse.Message = "governorate Added Successffully";
                return Ok(GeneralResponse);
                #endregion

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
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

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}

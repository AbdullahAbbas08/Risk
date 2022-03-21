using Risk_Business_Layer.IRepositories.ICustomer;
using Risk_Business_Layer.IUnitOfWork.IUnitOfWork_Crud;
using Risk_Business_Layer.Services;
using Risk_Business_Layer.Services.AuthenticationModels;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer Customer;
        private readonly IAuthService authService;
        private readonly IUnitOfWork_Crud unitOfWork;
        #region Decalre Variables
        #endregion

        #region Constructor
        public CustomerController(ICustomer _customer , IAuthService authService , IUnitOfWork_Crud unitOfWork1)
        {
            this.Customer = _customer;
            this.authService = authService;
            this.unitOfWork = unitOfWork1;
        }
        #endregion

      
        [HttpPost]
        public async Task<ActionResult<GeneralResponseSingleObject<string>>> PostCustomer(RegisterCustomerModel customer) 
        {
            try
            {
                #region Call Service
                var res =  await authService.RegisterCustomer(customer);
                return res;
                #endregion
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        
        [HttpPost("CustomerPhones")]
        public async Task<ActionResult<string>> CustomerPhones(List<(string,string)> customer)  
        {
            try
            {
                #region Call Service
                return await Customer.AddRange(customer);
                #endregion
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("GetCustomer")]
        public async Task<ActionResult<GeneralResponseSingleObject<Customer>>> GetCustomer(string phone)
        {
            try
            {
                #region Generate Returned Object TypeOf GeneralResponse
                GeneralResponseSingleObject<Customer> GeneralResponse = new GeneralResponseSingleObject<Customer>();
                #endregion

                #region Call Service
                var data = (await unitOfWork.Customer.Find(x => x.Mobile == phone)).FirstOrDefault();
                GeneralResponse.Data = data;
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
        
        
        [HttpGet("GetCustomerPhones")]
        public async Task<ActionResult<GeneralResponse<CustomerPhones>>> GetCustomerPhones(string id) 
        {
            try
            {
                #region Generate Returned Object TypeOf GeneralResponse
                GeneralResponse<CustomerPhones> GeneralResponse = new GeneralResponse<CustomerPhones>();
                #endregion

                #region Call Service
                var data = (await unitOfWork.CustomerPhones.Find(x => x.CustomerId == id)).ToList();
                GeneralResponse.Data = data;
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

    }
}

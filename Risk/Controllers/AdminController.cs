using Risk_Domain_Layer.DTO_S.Admin;
using Risk_Domain_Layer.DTO_S.AgentClient;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        #region Decalre Variables
        private readonly IAdminBusiness adminBusiness;
        #endregion

        #region Constructor
        public AdminController( IAdminBusiness adminBusiness)
        {
            this.adminBusiness = adminBusiness;
        }
        #endregion

        //#region Define API's => Call Methods Form Business Project 

        //[HttpPost]
        //public async Task<GeneralResponseSingleObject<AgentClient>> AssignClientsToAgent(AddAgentClientDto agentClient)
        //{
        //    try
        //    {
        //        return await AgentClientBusiness.AssginClientToAgent(new AgentClient { AgentId = agentClient.AgentId, ClientId = agentClient.ClientId });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex.InnerException;
        //    }
        //}
        //#endregion

        [HttpPost("ClientCallReport")]
        public async Task<GeneralResponse<ClientCallSearchResultReportDto>> ClientCallReport(ClientCallSearchInputReportDto model)
        {
            try
            {
                return await adminBusiness.ClientCallReport(model);

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        
        [HttpPost("CallStartEnd")]
        public async Task<GeneralResponse<ClientCallSearchResultReportDto>> Call_Start_End_Report(CallStart_End_Report_Dto model)
        {
            try
            {
                return await adminBusiness.Call_Start_End_Report(model);

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

using Risk_Domain_Layer.DTO_S.Admin;
using Risk_Domain_Layer.DTO_S.AgentClient;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        #region Decalre Variables
        private readonly IAgentClientBusiness AgentClientBusiness;
        private readonly IAdminBusiness adminBusiness;
        #endregion

        #region Constructor
        public AdminController(IAgentClientBusiness agentClient , IAdminBusiness adminBusiness)
        {
            this.AgentClientBusiness = agentClient;
            this.adminBusiness = adminBusiness;
        }
        #endregion

        #region Define API's => Call Methods Form Business Project 

        [HttpPost]
        public async Task<GeneralResponseSingleObject<AgentClient>> AssignClientsToAgent(AddAgentClientDto agentClient)
        {
            return await AgentClientBusiness.AssginClientToAgent( new AgentClient {AgentId = agentClient.AgentId,ClientId = agentClient.ClientId });

        }
        #endregion

        [HttpPost("ClientCallReport")]
        public async Task<GeneralResponse<ClientCallSearchResultReportDto>> ClientCallReport(ClientCallSearchInputReportDto model)
        {
            return await adminBusiness.ClientCallReport(model);
        }
    }
}

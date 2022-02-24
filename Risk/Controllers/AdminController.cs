using Risk_Domain_Layer.DTO_S.AgentClient;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        #region Decalre Variables
        private readonly IAgentClientBusiness AgentClientBusiness; 
        #endregion

        #region Constructor
        public AdminController(IAgentClientBusiness agentClient)
        {
            this.AgentClientBusiness = agentClient;
        }
        #endregion

        #region Define API's => Call Methods Form Business Project 

        [HttpPost]
        public async Task<GeneralResponseSingleObject<AgentClient>> AssignClientsToAgent(AddAgentClientDto agentClient)
        {
            return await AgentClientBusiness.AssginClientToAgent( new AgentClient {AgentId = agentClient.AgentId,ClientId = agentClient.ClientId });

        }
        #endregion
    }
}

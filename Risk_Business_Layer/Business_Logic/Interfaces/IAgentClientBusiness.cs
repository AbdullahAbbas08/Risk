namespace Risk_Business_Layer.IBusiness_Logic.Interfaces
{
    public interface IAgentClientBusiness
    {
        Task<GeneralResponseSingleObject<AgentClient>> AssginClientToAgent(AgentClient agentClient);
    }
}
 
using Risk_Business_Layer.IBusiness_Logic.Interfaces;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class AgentClientBusiness : IAgentClientBusiness 
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public AgentClientBusiness(IUnitOfWork_Crud unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<GeneralResponseSingleObject<AgentClient>> AssginClientToAgent(AgentClient agentClient)
        {
            GeneralResponseSingleObject<AgentClient> response = new GeneralResponseSingleObject<AgentClient>();
            AgentClient NewAgentClient;
           if(agentClient !=null)
            {
                var agent = await unitOfWork.Employee.Find(x => x.Id == agentClient.AgentId);
                var client =await unitOfWork.Client.Find(x => x.Id == agentClient.ClientId);

                if(agent.Count() >0 && client.Count() > 0)
                {
                    NewAgentClient = await unitOfWork.AgentClient.Add(agentClient);
                    response.Message = "تمت عملية الإضافة بنجاح";
                    response.Data = agentClient;
                }
                else
                {
                    response.Message = "كود العميل أو الموظف غير صالح برجاء المحاولة مرة أخرى";
                }
            }
           else
            {
                response.Message = "كود العميل و كود الموظف غير صالح برجاء المحاولة مرة أخرى";
            }
           
           return response;
           
        }
    }
}

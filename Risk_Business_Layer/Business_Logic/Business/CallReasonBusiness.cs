using Risk_Business_Layer.IBusiness_Logic.Interfaces;
using Risk_Domain_Layer.DTO_S.CallReason;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class CallReasonBusiness : ICallReasonBusiness<CallReason>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public CallReasonBusiness(IUnitOfWork_Crud unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(InsertCallReasonDto callReason)
        {
            try
            {
                if (callReason is not null)
                {
                    await unitOfWork.CallReason.Add(new CallReason { Title = callReason.Reason_Title,Order=callReason.Order});
                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var callReason = await unitOfWork.CallReason.Find(id);

                if (callReason != null)
                {
                    await unitOfWork.CallReason.Delete(id);
                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<GeneralResponse<CallReason>> GetAll() 
        { 
            try
            {
                GeneralResponse<CallReason> response = new GeneralResponse<CallReason>();
                response.Data =( await unitOfWork.CallReason.GetAll()).ToList();  
                return response;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task UpdateAsync(int id, CallReason callReason)
        {
            try
            {
                if (id != 0 && callReason.Id == id)
                {
                    unitOfWork.CallReason.Update(callReason);
                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

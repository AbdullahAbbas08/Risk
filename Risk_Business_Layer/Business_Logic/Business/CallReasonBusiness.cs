using Risk_Business_Layer.IBusiness_Logic.Interfaces;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class CallReasonBusiness : ICallReasonBusiness<CallReason>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public CallReasonBusiness(IUnitOfWork_Crud unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(CallReason callReason)
        {
            try
            {
                if (callReason is not null)
                {
                    await unitOfWork.CallReason.Add(callReason);
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

        public async Task<IEnumerable<CallReason>> GetByIdAsync(int? id)
        {
            try
            {
                if (id is not null)
                {
                    var callReason = await unitOfWork.CallReason.Find(c=>c.Id==id);

                    return callReason;
                }
                else
                {
                    var callReason = await unitOfWork.CallReason.GetAll();

                    return callReason;
                }
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

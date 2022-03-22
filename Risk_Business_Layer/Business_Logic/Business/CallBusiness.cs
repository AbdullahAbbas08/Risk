using Risk_Business_Layer.IBusiness_Logic.Interfaces;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class CallBusiness : ICallBusiness<Call>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public CallBusiness(IUnitOfWork_Crud unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponseSingleObject<Call>> AddAsync(Call call)
        {
            try
            {
                GeneralResponseSingleObject<Call> response = new GeneralResponseSingleObject<Call>();

                if (call is not null)
                {
                   var res = await unitOfWork.Call.Add(call);
                    await unitOfWork.SaveChangesAsync();
                    response.Data = call;
                    response.Message = "تم إضافة تفاصيل المكالمة  بنجاح";
                }
                return response;
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
                var call = await unitOfWork.Call.Find(id);

                if (call != null)
                {
                    await unitOfWork.Call.Delete(id);
                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GeneralResponse<Call>> GetAll()
        {
            try
            {
                GeneralResponse<Call> response = new GeneralResponse<Call>();
                response.Data = (await unitOfWork.Call.GetAll()).ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        //public async Task<GeneralResponseSingleObject<Call>> UpdateAsync(int id, Call model)
        //{
        //    try
        //    {
        //        GeneralResponseSingleObject<Call> response = new GeneralResponseSingleObject<Call>();
        //        var result = (await unitOfWork.Call.Find(x => x.Id == id)).FirstOrDefault();
        //        if (result == null)
        //            response.Message = "reason id not found ";
        //        else
        //        {
        //            result.
                   
        //            await unitOfWork.SaveChangesAsync();
        //            response.Data = model;
        //        }
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}
    }
}

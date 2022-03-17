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

        public async Task<GeneralResponseSingleObject<CallReason>> AddAsync(CallReason callReason)
        {
            try
            {
                GeneralResponseSingleObject<CallReason> response = new GeneralResponseSingleObject<CallReason>();

                if (callReason is not null)
                {
                   var res = await unitOfWork.CallReason.Add(callReason);
                    await unitOfWork.SaveChangesAsync();
                    response.Data = callReason;
                    response.Message = "تم ادخال السبب بنجاح";
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
                response.Data = (await unitOfWork.CallReason.GetAll()).OrderBy(x => x.Order).ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GeneralResponseSingleObject<CallReason>> UpdateAsync(int id, CallReason model)
        {
            try
            {
                GeneralResponseSingleObject<CallReason> response = new GeneralResponseSingleObject<CallReason>();
                var result = (await unitOfWork.CallReason.Find(x => x.Id == id)).FirstOrDefault();
                if (result == null)
                    response.Message = "reason id not found ";
                else
                {
                    result.Title = model.Title;
                    if (result.Order != model.Order)
                    {
                        model.Id = id;
                        response.Message = await UpdateOrder(model, result.Order);
                    }
                    await unitOfWork.SaveChangesAsync();
                    response.Data = model;
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        #region Function To Update Order
        /// <summary>
        /// Update  Order  
        /// </summary>
        /// <param name="Entity to Update"></param>
        /// <param name="Old Order"></param>
        /// <returns>
        /// update Orders between rows("Old Order and New Order")
        /// </returns>
        private async Task<string> UpdateOrder(CallReason model, int _OldOrder)
        {
            try
            {
                #region check object id exist
                var _EntityObj = (await unitOfWork.CallReason.Find(x => x.Id == model.Id)).FirstOrDefault();
                if (_EntityObj == null)
                    return "model Not Found";
                #endregion

                var _MaxOrder = (await unitOfWork.CallReason.GetAll()).Count();
                if (model.Order > _MaxOrder)
                    return " يجب ان يكون الترتيب اقل من أو يساوى " + _MaxOrder;

                if (model.Order <= 0)
                    model.Order = _EntityObj.Order;

                #region Handle Order Update
                //Get Max Order
                var __Entities = (await unitOfWork.CallReason.GetAll()).OrderBy(Obj => Obj.Order).ToList();

                int NewOrder = model.Order;
                int OldOrder = _OldOrder;

                if (OldOrder < NewOrder)
                {
                    var _SubObjects = __Entities.Where(obj => obj.Order > OldOrder && obj.Order <= NewOrder).OrderBy(o => o.Order).ToList();
                    foreach (var item in _SubObjects)
                    {
                        item.Order = item.Order - 1;
                        CallReason _result = unitOfWork.CallReason.Update(item);
                        if (_result == null)
                            return "update order operation failed !! ";
                        await unitOfWork.SaveChangesAsync();
                    }
                }
                else if (OldOrder > NewOrder)
                {
                    var _SubObjects = __Entities.Where(obj => obj.Order >= NewOrder && obj.Order < OldOrder).OrderBy(o => o.Order).ToList();
                    foreach (var item in _SubObjects)
                    {
                        item.Order = item.Order + 1;
                        CallReason _result = unitOfWork.CallReason.Update(item);
                        if (_result == null)
                            return "update order operation failed !! ";
                        await unitOfWork.SaveChangesAsync();
                    }
                }
                else
                {
                    return "order Incorrect ";
                }

                #endregion

                return "Update Operation Successffully";
            }
            catch
            {
                return "internal error ";
            }
        }
        #endregion
    }
}

using Risk_Business_Layer.IBusiness_Logic.Interfaces;

namespace Risk_Business_Layer.Repositories.Crud
{
    public class SourceMarketingBusiness : ISourceMarketingBusiness<SourceMarketing>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public SourceMarketingBusiness(IUnitOfWork_Crud unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponseSingleObject<SourceMarketing>> AddAsync(SourceMarketing sourceMarketing)
        {
            try
            {
                GeneralResponseSingleObject<SourceMarketing> response = new GeneralResponseSingleObject<SourceMarketing>();

                if (sourceMarketing is not null)
                {
                    response.Data = await unitOfWork.SourceMarketing.Add(sourceMarketing);
                    await unitOfWork.SaveChangesAsync();
                    response.Message = "تم إضافة المصدر بنجاح";
                }
                else
                    response.Message = "هناك خطأ حاول مرة خرى";

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
                var sourceMarketing = await unitOfWork.SourceMarketing.Find(id);

                if (sourceMarketing != null)
                {
                    await unitOfWork.SourceMarketing.Delete(id);
                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<GeneralResponse<SourceMarketing>> GetAll()
        {
            try
            {
                GeneralResponse<SourceMarketing> response = new GeneralResponse<SourceMarketing>();

                response.Data = (await unitOfWork.SourceMarketing.GetAll()).OrderByDescending(x => x.Order).ToList();
                return response;

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GeneralResponseSingleObject<SourceMarketing>> UpdateAsync(int id, SourceMarketing model)
        {
            try
            {
                GeneralResponseSingleObject<SourceMarketing> response = new GeneralResponseSingleObject<SourceMarketing>();
                var result = (await unitOfWork.SourceMarketing.Find(x => x.Id == id)).FirstOrDefault();
                if (result != null)
                {
                    result.Title = model.Title;
                    if (result.Order != model.Order)
                    {
                        model.Id = id;
                        response.Message = await UpdateOrder(model, result.Order);
                    }
                    await unitOfWork.SaveChangesAsync();
                }
                else
                    response.Message = "كود المصدر غير موجود";

                response.Data = model;
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
        private async Task<string> UpdateOrder(SourceMarketing model, int _OldOrder)
        {
            try
            {
                #region check object id exist
                var _EntityObj = (await unitOfWork.SourceMarketing.Find(x => x.Id == model.Id)).FirstOrDefault();
                if (_EntityObj == null)
                    return "model Not Found";
                #endregion

                var _MaxOrder = (await unitOfWork.SourceMarketing.GetAll()).Count();
                if (model.Order > _MaxOrder)
                    return " يجب ان يكون الترتيب اقل من أو يساوى " + _MaxOrder;

                if (model.Order <= 0)
                    model.Order = _EntityObj.Order;

                #region Handle Order Update
                //Get Max Order
                var __Entities = (await unitOfWork.SourceMarketing.GetAll()).OrderBy(Obj => Obj.Order).ToList();

                int NewOrder = model.Order;
                int OldOrder = _OldOrder;

                if (OldOrder < NewOrder)
                {
                    var _SubObjects = __Entities.Where(obj => obj.Order > OldOrder && obj.Order <= NewOrder).OrderBy(o => o.Order).ToList();
                    foreach (var item in _SubObjects)
                    {
                        item.Order = item.Order - 1;
                        SourceMarketing _result = unitOfWork.SourceMarketing.Update(item);
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
                        SourceMarketing _result = unitOfWork.SourceMarketing.Update(item);
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

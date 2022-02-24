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

        public async Task AddAsync(SourceMarketing sourceMarketing)
        {
            try
            {
                if (sourceMarketing is not null)
                {
                    await unitOfWork.SourceMarketing.Add(sourceMarketing);
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

        public async Task<IEnumerable<SourceMarketing>> GetByIdAsync(int? id)
        {
            try
            {
                if (id is not null)
                {
                    var sourceMarketings = await unitOfWork.SourceMarketing.Find(c=>c.Id==id);

                    return sourceMarketings;
                }
                else
                {
                    var sourceMarketings = await unitOfWork.SourceMarketing.GetAll();

                    return sourceMarketings;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task UpdateAsync(int id, SourceMarketing sourceMarketing)
        {
            try
            {
                if (id != 0 && sourceMarketing.Id == id)
                {
                    unitOfWork.SourceMarketing.Update(sourceMarketing);
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

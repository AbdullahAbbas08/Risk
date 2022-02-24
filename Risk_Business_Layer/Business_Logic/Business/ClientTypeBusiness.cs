using Risk_Business_Layer.IBusiness_Logic.Interfaces;
using Risk_Domain_Layer.DTO_S.ClientType;

namespace Risk_Business_Layer.Repositories.Crud
{
    public class ClientTypeBusiness : IClientTypeBusiness<ClientType>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public ClientTypeBusiness(IUnitOfWork_Crud unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponseSingleObject<ClientType>> AddAsync(AddClientTypeDto model) 
        {
            try
            {
                GeneralResponseSingleObject<ClientType> response = new GeneralResponseSingleObject<ClientType>();
                if (string.IsNullOrEmpty(model.Title))
                {
                    var res = await unitOfWork.ClientType.Find(x => x.Title == model.Title);
                    if (res != null)
                    {
                        response.Data = await unitOfWork.ClientType.Add(new ClientType { Title = model.Title });
                        await unitOfWork.SaveChangesAsync();
                        response.Message = "Client Type Added Successffully";
                    }
                    else
                        response.Message = "Client Type Already Exist";
                }
                else
                    response.Message = "You Must Enter Client Type Tite";
                return response;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GeneralResponseSingleObject<ClientType>> DeleteAsync(int id)
        {
            try
            {
                GeneralResponseSingleObject<ClientType> response = new GeneralResponseSingleObject<ClientType>();
                var clientType = await unitOfWork.ClientType.Find(id);

                if (clientType != null)
                {
                    await unitOfWork.ClientType.Delete(id);
                    await unitOfWork.SaveChangesAsync();
                    response.Message = "تمت عملية الحذف بنجاح";
                }
                else
                    response.Message = "الكود غير موجود أو غير صحيح";
                return response;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<GeneralResponse<ClientType>> GetAll()
        {
            try 
            {
                GeneralResponse<ClientType> response = new GeneralResponse<ClientType>();

                response.Data =  (await unitOfWork.ClientType.GetAll()).ToList();
                response.Message = "Successffully";
                return response;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GeneralResponseSingleObject<ClientType>> UpdateAsync(int id, ClientType model)
        {
            try
            {
                GeneralResponseSingleObject<ClientType> response = new GeneralResponseSingleObject<ClientType>();
                if (id > 0)
                {
                    var clientType = await unitOfWork.ClientType.Find(id);
                    if(clientType != null)
                    {
                        response.Data =  unitOfWork.ClientType.Update(new ClientType { TypeId = id , Title=model.Title});
                        await unitOfWork.SaveChangesAsync();
                        response.Message = "Client Type Updated Successffully";
                    }
                    else
                        response.Message = "Client Type Not Found ! ";
                }
                else
                    response.Message = "You Must Insert Client Type ID At First ! ";
                return response;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

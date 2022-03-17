using Risk_Business_Layer.IBusiness_Logic.Interfaces;
using Risk_Data_Access_Layer;
using Risk_Domain_Layer.DTO_S.ClientType;

namespace Risk_Business_Layer.Repositories.Crud
{
    public class ClientTypeBusiness : Crud<ClientType>, IClientTypeBusiness<ClientType>
    {
        private readonly IUnitOfWork_Crud unitOfWork;

        public ClientTypeBusiness(IUnitOfWork_Crud unitOfWork, RiskDbContext riskDbContext):base(riskDbContext)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponseSingleObject<ClientType>> AddClientType(AddClientTypeDto model) 
        {
            try
            {
                GeneralResponseSingleObject<ClientType> response = new GeneralResponseSingleObject<ClientType>();
                if (!string.IsNullOrEmpty(model.Title))
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

        public async Task<GeneralResponseSingleObject<ClientType>> DeleteClientType(int id)
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

        public async Task<GeneralResponse<ClientType>> GetAllClientType(int? id)
        {
            try 
            {
                GeneralResponse<ClientType> response = new GeneralResponse<ClientType>();

                if(id !=null)
                {
                    var clientCall = (await unitOfWork.CallReasonClientType.Find(x => x.CallReasonId == id)).ToList();
                    var clientTypes = clientCall.Select(x => x.ClientTypeId).ToList();
                    response.Data = (await unitOfWork.ClientType.Find(x => clientTypes.Contains(x.TypeId))).ToList();

                }
                else
                {
                    response.Data = (await unitOfWork.ClientType.GetAll()).ToList();

                }
                response.Message = "Successffully";
                return response;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GeneralResponseSingleObject<ClientType>> UpdateClientType(int id, ClientType model)
        {
            try
            {
                GeneralResponseSingleObject<ClientType> response = new GeneralResponseSingleObject<ClientType>();
                if (id > 0)
                {
                    var clientType = await unitOfWork.ClientType.Find(id);
                    if(clientType != null)
                    {
                        //response.Data =  unitOfWork.ClientType.Update(new ClientType { TypeId = id , Title=model.Title});
                        clientType.Title = model.Title;
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

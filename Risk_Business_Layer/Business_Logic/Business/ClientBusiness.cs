using Microsoft.Extensions.Options;
using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Business_Layer.Helpers;
using Risk_Business_Layer.IRepositories.IClient;
using Risk_Business_Layer.Services.Authentication;
using Risk_Domain_Layer.DTO_S;
using Risk_Domain_Layer.DTO_S.Client;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class ClientBusiness : IClientBusiness
    {
        private readonly IClient unitOfWork;
        private readonly Helper helper;

        public ClientBusiness(IClient unitOfWork , IOptions<Helper> helper )
        {
            this.unitOfWork = unitOfWork;
            this.helper = helper.Value;
        }
        public Task AssignClientToAgent(Risk_Data_Access_Layer.Models.Client Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralResponseSingleObject<EmptyResponse>> DeleteClient(string ID)
        {
            GeneralResponseSingleObject<EmptyResponse> response = new GeneralResponseSingleObject<EmptyResponse>();
            bool res = unitOfWork.DeleteUser(ID);
            if (res)
                response.Message = "تم حذف العميل بنجاح";
            else
                response.Message = "هناك مشكلة ؟ حاول مرة أخرى";
            return response;
        }

       

        public async Task<GeneralResponse<GetClientDto>> GetAll()
        {
            GeneralResponse<GetClientDto> response = new GeneralResponse<GetClientDto>();
            response.Data = (await unitOfWork.GetAllWithRelatedTitles()).ToList();
            response.Message = "data returned Successfully";
            return response;
        }
        public async Task<GeneralResponse<GetClientDto>> FilterClient()
        {
            GeneralResponse<GetClientDto> response = new GeneralResponse<GetClientDto>();

            response.Data = (await unitOfWork.GetAllWithRelatedTitles()).ToList();
            response.Message = "data returned Successfully";
            return response;
        }

        public async Task<GeneralResponse<IdNameList>> GetAllIdName()
        {
            GeneralResponse<IdNameList> response = new GeneralResponse<IdNameList>();
            response.Data = (await unitOfWork.GetAllWithRelatedTitles()).Select(x=>
                new IdNameList
                {
                    Id = x.ClientId,
                    Name = x.Name,
                }).ToList();
            response.Message = "data returned Successfully";
            return response;
        }

        public async Task<GeneralResponse<GetClientDto>> FilterClientWithRelatedTitles(string? ClientName, string? Mobile, int? ClientType)
        {
            GeneralResponse<GetClientDto> response = new GeneralResponse<GetClientDto>();
            response.Data = (await unitOfWork.FilterClientWithRelatedTitles(ClientName , Mobile , ClientType)).ToList();
            response.Message = "data returned Successfully";
            return response;
        }
    }
}

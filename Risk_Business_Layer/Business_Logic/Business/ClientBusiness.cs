using Microsoft.Extensions.Options;
using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Business_Layer.Helpers;
using Risk_Business_Layer.IRepositories.IClient;
using Risk_Domain_Layer.DTO_S.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<GeneralResponse<GetClientDto>> GetAll()
        {
            GeneralResponse<GetClientDto> response = new GeneralResponse<GetClientDto>();
            response.Data = (await unitOfWork.GetAllWithRelatedTitles()).ToList();
            response.Message = "data returned Successfully";
            return response;
        }
    }
}

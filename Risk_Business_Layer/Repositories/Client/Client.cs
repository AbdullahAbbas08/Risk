using Microsoft.EntityFrameworkCore;
using Risk_Business_Layer.IRepositories.IClient;
using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Business_Layer.Repositories.Crud;
using Risk_Data_Access_Layer;
using Risk_Domain_Layer.DTO_S.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Repositories.Client
{
    public class Client : Crud<Risk_Data_Access_Layer.Models.Client>, IClient
    {
        private readonly RiskDbContext riskDbContext;

        public Client(RiskDbContext riskDbContext) : base(riskDbContext)
        {
            this.riskDbContext = riskDbContext;
        }

        public async Task<IEnumerable<GetClientDto>> GetAllWithRelatedTitles()
        {
            var Client =  await riskDbContext.Clients.Include(x => x.City).Include(x => x.ClientType).Select(x => new
            GetClientDto {
                CityTitle = x.City.Title,
                ClientTypeTitle = x.ClientType.Title,
                GovernorateTitle = x.City.Governorate.Title,
                GovernorateId = x.City.Governorate.Id,
                ClientId = x.Id,
                Address = x.Address,
                CityId = x.CityId,
                ClientTypeId = x.ClientTypeId,
                LogoPath = x.LogoPath,
                Mobile = x.Mobile,
                Name = x.Name,
                UserName = x.UserName,
                password=x.PasswordHash
            }).ToListAsync();

            return Client;
        }
    }
}

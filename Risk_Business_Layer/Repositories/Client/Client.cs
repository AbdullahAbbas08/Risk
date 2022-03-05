using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Risk_Business_Layer.Helpers;
using Risk_Business_Layer.IRepositories.IClient;
using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Business_Layer.Repositories.Crud;
using Risk_Business_Layer.Services.Authentication;
using Risk_Data_Access_Layer;
using Risk_Domain_Layer.DTO_S.Client;

namespace Risk_Business_Layer.Repositories.Client
{
    public class Client : Crud<Risk_Data_Access_Layer.Models.Client>, IClient
    {
        private readonly RiskDbContext riskDbContext;

        public Client(RiskDbContext riskDbContext) : base(riskDbContext)
        {
            this.riskDbContext = riskDbContext;
        }

        public bool DeleteUser(string ID)
        {
            var entity = (from x in riskDbContext.Clients
                          where x.Id == ID
                          select x).FirstOrDefault();

            if (entity != null)
            {
                riskDbContext.Clients.Remove(entity);
                riskDbContext.Users.Remove(entity);
                riskDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public async Task<IEnumerable<GetClientDto>> GetAllWithRelatedTitles()
        {
            var Client = await riskDbContext.Clients.Include(x => x.City).Include(x => x.ClientType).Select(x =>
           new GetClientDto
           {
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
               password = x.PasswordHash
           }).ToListAsync();

            return Client;
        }

        public async Task<GeneralResponseSingleObject<Risk_Data_Access_Layer.Models.Client>> UpdateUser(UpdateClientModel model)
        {
            GeneralResponseSingleObject<Risk_Data_Access_Layer.Models.Client> response = new GeneralResponseSingleObject<Risk_Data_Access_Layer.Models.Client>();

                Risk_Data_Access_Layer.Models.Client client = (from item in riskDbContext.Clients
                                                               where item.Id == model.Id
                                                               select item).FirstOrDefault();

                if (client != null)
                {
                    client.CityId = model.CityId;
                    client.ClientTypeId = model.ClientTypeId;
                    client.LogoPath = model.LogoPath;
                }

            ApplicationUser user = (from item in riskDbContext.Users
                                                                  where item.Id == model.Id
                                                                  select item).FirstOrDefault();
            if (user != null)
            {
                user.Name = model.Name;
                user.UserName = model.UserName;
                user.Mobile = model.Mobile;
                user.PasswordHash = model.Password;

                response.Message = "تم تعديل العميل بنجاح";
            }

            response.Data = client;
            riskDbContext.SaveChangesAsync();

            return response ;
        }
    }
}

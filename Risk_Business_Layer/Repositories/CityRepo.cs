using Microsoft.EntityFrameworkCore;
using Risk_Business_Layer.IRepositories.IClient;
using Risk_Business_Layer.Repositories.Crud;
using Risk_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Repositories
{
    public class CityRepo : Crud<City>, ICityRepo
    {
        #region Declare Variables
        private readonly RiskDbContext riskDbContext;
        #endregion

        #region Constructor
        public CityRepo(RiskDbContext riskDbContext):base(riskDbContext)
        {
            this.riskDbContext = riskDbContext;
        }
        #endregion

        public async Task<GeneralResponse<City>> GetCitiesWithGovernorate()
        {
            GeneralResponse<City> generalResponse = new GeneralResponse<City>();
            generalResponse.Data = riskDbContext.cities.Include(x=>x.Governorate).ToList();
            generalResponse.Message = "success";
            return  generalResponse;
        }
    }
}

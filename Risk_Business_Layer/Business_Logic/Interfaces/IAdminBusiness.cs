using Risk_Domain_Layer.DTO_S.Admin;

namespace Risk_Business_Layer.IBusiness_Logic.Interfaces
{
    public interface IAdminBusiness 
    {
        Task<GeneralResponse<ClientCallSearchResultReportDto>> ClientCallReport(ClientCallSearchInputReportDto model);
        Task<GeneralResponse<ClientCallSearchResultReportDto>> Call_Start_End_Report(CallStart_End_Report_Dto model);
    }

}
    
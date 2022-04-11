namespace Risk_Domain_Layer.DTO_S.Admin
{
    public class ClientCallSearchResultReportDto
    {
        public string AgentName { get; set; }
        public string AgentId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string MobileNumber { get; set; }
        public int Gender { get; set; }
        public int CallType { get; set; }
        public bool Satisfy { get; set; }

        public string mobile { get; set; }
        public string CityName { get; set; }
        public int CityId { get; set; }
        public int CallReasonId { get; set; }
        
        public string GovernorateTitle { get; set; }
        public int GovernorateId { get; set; }
        public string Address { get; set; } 
        //public string SourceOfMarket { get; set; }
        public string CallDescription { get; set; }
        public string Notes { get; set; }
        public DateTime DOB { get; set; }
        public DateTime CallStart { get; set; }
        public DateTime CallEnd { get; set; }
    }
}

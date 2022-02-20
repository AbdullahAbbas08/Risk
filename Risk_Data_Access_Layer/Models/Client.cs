using Microsoft.AspNetCore.Http;

namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "Clients", Schema = "dbo")]
    public class Client : ApplicationUser
    {
        [Required]
        public string LogoPath { get; set; }

        [NotMapped]
        public IFormFile Logo { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public  City City { get; set; }

        public int ClientTypeId { get; set; } 

        [ForeignKey("ClientTypeId")]
        public   ClientType ClientType { get; set; }
        public  ICollection<CallReason> CallReasons { get; set; }
    }

}

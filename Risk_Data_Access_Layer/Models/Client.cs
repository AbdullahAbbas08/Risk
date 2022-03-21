using Microsoft.AspNetCore.Http;

namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "Clients", Schema = "dbo")]
    public class Client : ApplicationUser
    {
        [Required]
        public string LogoPath { get; set; }

        [NotMapped]
        public IFormFile? Logo { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [Required]
        public int ClientTypeId { get; set; } 

        [ForeignKey("ClientTypeId")]
        public virtual ClientType ClientType { get; set; }

        //public ICollection<Customer> Customer { get; set; }
    }
}

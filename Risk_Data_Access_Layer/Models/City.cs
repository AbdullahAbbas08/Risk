
using System.Text.Json.Serialization;

namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "Cities", Schema = "dbo")]
    public class City
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(150)"), Display(Name = "City Title")]
        public string Title { get; set; }

        public int GovernorateId { get; set; }


        [ForeignKey("GovernorateId")]
        public Governorate Governorate { get; set; }
    }

}

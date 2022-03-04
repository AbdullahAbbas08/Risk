
using System.Text.Json.Serialization;

namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "Governorates", Schema = "dbo")]
    public  class Governorate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(150)"), Display(Name = "Governorate Title")]
        public string Title { get; set; }


    }

}

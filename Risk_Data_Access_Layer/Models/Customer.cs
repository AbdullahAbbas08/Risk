namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "Customers", Schema = "dbo")]
    public class Customer: ApplicationUser
    {
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; } 
        

        [Column(TypeName = "tinyint")]
        public int Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }


        [Column(TypeName = "varchar(11)"), MaxLength(11)]
        public string Mobile2 { get; set; }

        [Column(TypeName = "varchar(11)"), MaxLength(11)]
        public string Phone { get; set; } 

        public string ClientId { get; set; }
         
        
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        //public int MobileId { get; set; }

        //[ForeignKey("MobileId")] 
        //public virtual MobilePhone MobilePhone  { get; set; }
    }
}

namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "Employees", Schema = "dbo")]
    public class Employee : ApplicationUser
    {
        [Required]
        [Column(TypeName = "varchar(14)")]
        [MaxLength(14)]
        [MinLength(14)]
        [Display(Name = "National Id")]
        public string NationalId { get; set; }
    }

    public class AgentClient 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AgentId { get; set; }

        public string ClientId { get; set; }

        [Required]
        [ForeignKey("AgentId")]
        public Employee Employees { get; set; }

        [Required]
        [ForeignKey("ClientId")]
        public Client Clients { get; set; }
    } 


}

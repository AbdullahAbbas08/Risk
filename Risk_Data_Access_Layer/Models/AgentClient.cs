namespace Risk_Data_Access_Layer.Models
{
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

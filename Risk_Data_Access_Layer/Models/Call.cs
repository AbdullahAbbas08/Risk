namespace Risk_Data_Access_Layer.Models
{
    public class Call
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Reason { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }


        [Column(TypeName = "nvarchar(max)")]
        public string Notes { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public int CallType { get; set; }

        public int SourceMarketId { get; set; }

        public bool Satisfy { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime StartCall { get; set; }

        public DateTime EndCall { get; set; }




        [ForeignKey("SourceMarketId"),JsonIgnore]
        public SourceMarketing SourceMarketing { get; set; }



        public int CallReasonId { get; set; }

        [ForeignKey("CallReasonId"), JsonIgnore]
        public CallReason CallReason { get; set; }


        [Column(TypeName = "nvarchar(450)")]
        public string customerId { get; set; }

        [ForeignKey("customerId")]
        public Customer customer { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string CustomerServiceId { get; set; }

        [ForeignKey("CustomerServiceId"), JsonIgnore]
        public Employee Employees { get; set; }


        [Column(TypeName = "nvarchar(450)")]
        public string ClientId { get; set; }
        [ForeignKey("ClientId"), JsonIgnore]
        public Client Client { get; set; }

    }
}
 
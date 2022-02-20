namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "CallReasons", Schema = "dbo")]
    public class CallReason
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Call Reason Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Call Reason Order")]
        public int Order { get; set; }

        [JsonIgnore]
        public  ICollection<Client> Clients { get; set; }
    }
}

namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "ClientTypes", Schema = "dbo")]
    public class ClientType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Client Type Title")]
        public string Title { get; set; }

        //public ICollection<CallReason> CallReasons { get; set; }
    }

}

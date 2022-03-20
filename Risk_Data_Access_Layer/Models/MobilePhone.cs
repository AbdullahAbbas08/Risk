namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "MobilePhones",Schema ="dbo")]
    public class MobilePhone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(11)")]
        [MaxLength(11)]
        public string Mobile { get; set; }


        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}

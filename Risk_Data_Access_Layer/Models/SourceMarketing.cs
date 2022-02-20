namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "SourceOfMarketing", Schema = "dbo")]
    public class SourceMarketing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Source Of Marketing Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Source Of Marketing Order")]
        public int Order { get; set; }
    }

}

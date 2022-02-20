namespace Risk_Data_Access_Layer.Models
{
    public abstract class ApplicationUser : IdentityUser
    {
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(11)")]
        [MaxLength(11)]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; } 

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }

}

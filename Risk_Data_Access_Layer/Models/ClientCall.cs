namespace Risk_Data_Access_Layer.Models
{
    public class ClientCall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CallId { get; set; }
        public string ClientId { get; set; }

        [ForeignKey("string")]
        public Client Client { get; set; }

        [ForeignKey("CallId")]
        public Call Call { get; set; } 
    }

}

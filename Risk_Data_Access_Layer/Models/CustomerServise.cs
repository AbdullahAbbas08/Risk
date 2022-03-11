namespace Risk_Data_Access_Layer.Models
{
    [Table(name: "CustomerServise", Schema = "dbo")]
    public class CustomerServise : Employee
    {
        public ICollection<Client> Client { get; set; }
    }
}

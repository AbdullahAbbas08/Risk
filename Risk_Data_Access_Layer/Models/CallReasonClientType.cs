namespace Risk_Data_Access_Layer.Models
{
    public class CallReasonClientType 
    {
        public int Id { get; set; }
        public int CallReasonId { get; set; }

        public int ClientTypeId { get; set; } 

        [ForeignKey("ClientTypeId")]
        public virtual ClientType clientType { get; set; }

        [ForeignKey("CallReasonId")]
        public virtual CallReason CallReason { get; set; }
    }

}  
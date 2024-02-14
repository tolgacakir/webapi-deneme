namespace bynrcargo.Api.Entities
{
    public class GetStatusResponse
    {
        public string DeliveryCode { get; set; }
        public DeliveryStatus Status { get; set; }
        public string StatusDescription {get;set;}
    }
}
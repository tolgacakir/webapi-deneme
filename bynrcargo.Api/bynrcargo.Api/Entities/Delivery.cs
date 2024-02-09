namespace Delivery.Controllers
{

    public class Delivery

    {
        public int DeliveryCode { get; set; }
        public string ReceiverAddress { get; set; }

        public string SenderAddress { get; set; }
        public enum Status { Created, InTransit, Delivered, NotDelivered }
        
    }



}
namespace Delivery.Controllers
{
    public class Delivery

    {
        public int DeliveryCode { get; set; }
        public string ReceiverAddress {  get; set; }

        public string SenderAddress { get; set; }
        public string Status { get; }
        public  Delivery() {
            this.Status = "Sipariş Alındı";
            
        }
    }
    
}

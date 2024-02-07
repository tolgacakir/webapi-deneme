namespace Delivery.Controllers
{
    public class Delivery

    {
        public int deliveryCode { get; set; }
        public string receiverAddress {  get; set; }

        public string senderAddress { get; set; }
        public string status { get; }
        public  Delivery() {
            this.status = "Sipariş Alındı";
            
        }
    }
    
}

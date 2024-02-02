namespace task1.Controllers
{
    public class Delivery

    {
        public int deliveryCode { get; set; }
        public string receiverAddress {  get; set; }

        public string senderAddress { get; set; }
        public string Status { get; }
        public  Delivery() {
            this.Status = "Sipariş Alındı";
        
        }
    }
    
}

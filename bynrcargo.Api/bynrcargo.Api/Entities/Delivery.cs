﻿namespace bynrcargo.Api.Entities
{
    public class Delivery
    {
        public Guid DeliveryId {get;set;}
        public string DeliveryCode { get; set; }
        public string ReceiverAddress { get; set; }
        public string SenderAddress { get; set; }
        public DeliveryStatus Status {get; private set;}

        public Delivery()
        {
            Status = DeliveryStatus.Created;
        }

        public void SetStatusCanceled()
        {
            if(Status != Created)
            {
                throw new Exception("Mevcut statude bu delivery iptal edilemez.");
            }
            Status = DeliveryStatus.Canceled;
        }

    }
    
    
}

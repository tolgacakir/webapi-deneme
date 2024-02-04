



using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoController : ControllerBase
    {
         static List<Delivery> Shipment = new List<Delivery> { };
        
       


        [HttpGet]
        public List<Delivery> Get()
        {

            
            return Shipment;
        }
        [HttpPost("Delivery/Add")]
        public Delivery Post(Delivery delivery)
        {
            Shipment.Add(delivery);
            return delivery;

            

        }
        [HttpGet("Status/{DeliveryId}")]
        public Delivery Get(int DeliveryId)
        {
            var delivery = Shipment.FirstOrDefault(d => d.deliveryCode == DeliveryId);
            if(delivery == null)
            {
                Response.StatusCode = 404;
            }
            
           
            
            return Shipment.FirstOrDefault(d => d.deliveryCode == DeliveryId);
            
        }

        [HttpDelete("Delivery/Cancel/{DeliveryId}")]
        public  Delivery Delete(int DeliveryId)
        {
            var cancel= Shipment.FirstOrDefault(d=>d.deliveryCode==DeliveryId);
            if(cancel == null)
            {
                Response.StatusCode = 404;
            }
            Shipment.Remove(cancel);
            return cancel;
        }
        

    }
    
}
    

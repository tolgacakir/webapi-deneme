using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        [HttpPost]
        public Delivery Post(Delivery delivery)
        {
            Shipment.Add(delivery);
            return delivery;

            

        }
        [HttpGet("{DeliveryId}")]
        public Delivery Get(int DeliveryId)
        {
            var delivery = Shipment.FirstOrDefault(d => d.deliveryCode == DeliveryId);
            if(delivery == null)
            {
                Response.StatusCode = 404;
            }
            
           
            
            return Shipment.FirstOrDefault(d => d.deliveryCode == DeliveryId);
            
        }
       

    }
}
    

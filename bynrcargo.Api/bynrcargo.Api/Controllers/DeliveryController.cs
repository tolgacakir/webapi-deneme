



using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
         static List<Delivery> _delivery = new List<Delivery> { };
        
       


        [HttpGet]
        public List<Delivery> Get()
        {

            
            return _delivery;
        }
        [HttpPost("Delivery/Add")]
        public Delivery Post(Delivery delivery)
        {
            _delivery.Add(delivery);
            return delivery;

            

        }
        [HttpGet("Status/{DeliveryId}")]
        public Delivery Get(int DeliveryId)
        {
            var delivery = _delivery.FirstOrDefault(d => d.deliveryCode == DeliveryId);
            if(delivery == null)
            {
                Response.StatusCode = 404;
            }
            
           
            
            return _delivery.FirstOrDefault(d => d.deliveryCode == DeliveryId);
            
        }

        [HttpDelete("Delivery/Cancel/{DeliveryId}")]
        public  Delivery Delete(int DeliveryId)
        {
            var cancel= _delivery.FirstOrDefault(d=>d.deliveryCode==DeliveryId);
            if(cancel == null)
            {
                Response.StatusCode = 404;
            }
            _delivery.Remove(cancel);
            return cancel;
        }
        

    }
    
}
    





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




        [HttpGet("List")]
        public List<Delivery> Get()
        {
            if (_delivery.Count==0)
            {
                Response.StatusCode = 204;
            }

            return _delivery;
        }
        [HttpPost("Add")]
        public Delivery Post(Delivery delivery)
        {
            _delivery.Add(delivery);
            if (!_delivery.Contains(delivery))
            {
                Response.StatusCode = 400;

            }
            Response.StatusCode = 201;
            return delivery;






        }
        [HttpGet("Status/{DeliveryId}")]
        public Delivery Get(int DeliveryId)
        {
            var delivery = _delivery.FirstOrDefault(d => d.deliveryCode == DeliveryId);
            if (delivery == null)
            {
                Response.StatusCode = 404;
            }



            return _delivery.FirstOrDefault(d => d.deliveryCode == DeliveryId);

        }

        [HttpDelete("Cancel/{DeliveryId}")]

        public Delivery Delete(int DeliveryId)
        {
            var cancel = _delivery.FirstOrDefault(d => d.deliveryCode == DeliveryId);
            if (!_delivery.Contains(cancel))
            {

                Response.StatusCode = 404;

            }
            else { Response.StatusCode = 202; }
            _delivery.Remove(cancel);

            return cancel;
            
        }
    }
}
    

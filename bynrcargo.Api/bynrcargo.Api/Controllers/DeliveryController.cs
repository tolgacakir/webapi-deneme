


using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace Delivery.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
        static List<Delivery> _delivery = new List<Delivery> { };

        [HttpGet("List")]
        public IActionResult GetAll()
        {
            if (_delivery.Count==0)
            {
                return NotFound("Uygun Siparis Bulunamadı");
            }
            return Ok(_delivery);
        }
        [HttpPost("Add")]
        public IActionResult Post(Delivery delivery)
        {  
            if (_delivery.Any(d=>d.DeliveryCode==delivery.DeliveryCode))
            {
                
                return Conflict();
            }
            else
            {
                _delivery.Add(delivery);
                return Ok(delivery);
            }
       }
        [HttpGet("Status/{DeliveryId}")]
        public IActionResult GetStatus(int DeliveryId)
        {
            var delivery = _delivery.FirstOrDefault(d=> d.DeliveryCode == DeliveryId);
            if (delivery == null)
            {
                return NotFound();
            }
            var deliveryStatus = new {DeliveryId = delivery.DeliveryCode , StatusCode = delivery.Status};
                  return Ok(deliveryStatus);
        }
        [HttpDelete("Cancel/{DeliveryId}")]

        public IActionResult Delete(int DeliveryId)
        {
            var cancel = _delivery.FirstOrDefault(d => d.DeliveryCode == DeliveryId);
            if (!_delivery.Contains(cancel))
            {
                return NotFound("Bu Id'ye Ait Bir Siparis Bulunamadı.");
            }          
            _delivery.Remove(cancel);
            return Accepted();
                      
        }
    }
}
    

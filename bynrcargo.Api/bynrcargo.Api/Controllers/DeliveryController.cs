using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace bynrcargo.Api.Entities
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
        static List<Delivery> _delivery = new List<Delivery> { };

        [HttpGet("List")]
        public IActionResult GetList()
        {
            if (_delivery.Count == 0)
            {
                return NotFound("Uygun Siparis Bulunamadı");
            }
            return Ok(_delivery);
        }

        [HttpPost("Add")]
        public IActionResult Add(AddDeliveryRequest request)
        {
            if (_delivery.Any(d => d.DeliveryCode == request.DeliveryCode))
            {
                return Conflict();
            }

            Delivery delivery = new Delivery
            {
                DeliveryCode = request.DeliveryCode,
                ReceiverAddress = request.ReceiverAddress,
                SenderAddress = request.SenderAddress,
            };

            _delivery.Add(delivery);
            return Ok();
        }

        [HttpGet("Status/{deliveryCode}")]
        public IActionResult GetStatus(string deliveryCode)
        {
            var delivery = _delivery.FirstOrDefault(d => d.DeliveryCode == deliveryCode);
            if (delivery == null)
            {
                return NotFound();
            }

            GetStatusResponse response = new GetStatusResponse
            {
                DeliveryCode = delivery.DeliveryCode,
                Status = delivery.Status,
                StatusDescription = delivery.Status.ToString()
            };

            return Ok(response);
        }

        [HttpDelete("Cancel/{deliveryCode}")]
        public IActionResult Cancel(string deliveryCode)
        {
            var delivery = _delivery.FirstOrDefault(d => d.DeliveryCode == deliveryCode);
            if (delivery == null)
            {
                return NotFound();
            }

            delivery.SetStatusCanceled();

            return Accepted();
        }
    }
}

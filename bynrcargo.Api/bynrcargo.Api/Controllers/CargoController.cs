using Microsoft.AspNetCore.Mvc;
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
            return Shipment.FirstOrDefault(d => d.DeliveryId == DeliveryId);
        }
        [HttpPatch("{DeliveryId}")]
        public void Patch(int DeliveryId)
        {
            var deliveryToUpdate = Shipment.FirstOrDefault(d => d.DeliveryId == DeliveryId);
            deliveryToUpdate.Status = "İptal Edildi";
        }

    }
}
    

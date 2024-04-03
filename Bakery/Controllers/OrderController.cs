using Bakery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bakery.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BakeryContext _context;
        public OrderController(BakeryContext context)
        {
            _context = context;
        }



        [HttpGet("{id}")]
        public IActionResult GetOrder(int id, string select)
        {
            try
            {
                /*
                // Mangler model, skal rettes til
                var selectedOrder = _context.Orders.FirstOrDefault(o => o.Id == id);

                if (selectedOrder == null) return NotFound("Order not found");


                var selectedProperties = new Dictionary<string, object>();
                var properties = select.Split(',');
                foreach (var property in properties)
                {
                    switch (property.Trim().ToLower())
                    {
                        case "deliveryplace":
                            selectedProperties["Delivery Place"] = selectedOrder.DeliveryPlace;
                            break;
                        case "deliverydate":
                            selectedProperties["Delivery Date"] = selectedOrder.DeliveryDate;
                            break;
                    }
                }
                return Ok(selectedProperties);
                */
                return NotFound("Order not found"); //TEMP: Mangler model, skal rettes til
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/baking_goods")]
        public IActionResult GetBakingGoodsOfOrder(int id)
        {
            /*
            var selectedOrder = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (selectedOrder == null) return NotFound("Order not found");

            // Somehow get baking goods of the selectedOrder and return

            */

            return Ok();

        }

        [HttpGet("{id}/packets")]
        public IActionResult GetPacketsOfOrder(int id)
        {
            // Return trackids
            // Måske også lave det her til en select? /v1/orders/packets?select=Trackid
            return Ok();
        }
    }
}

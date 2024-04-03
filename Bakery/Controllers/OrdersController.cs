using Bakery.Dtos;
using Bakery.Models;
using Bakery.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderRepository OrderRepository;
        private readonly BakingGoodRepository BakingGoodRepository;

        public OrdersController(OrderRepository orderRepository, BakingGoodRepository bakingGoodRepository)
        {
            OrderRepository = orderRepository;
            BakingGoodRepository = bakingGoodRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id, string? select)
        {
            var selectedOrder = await OrderRepository.GetOrderById(id);
            if (selectedOrder == null) return NotFound("Order not found");

            OrderDto orderDto = OrderDto.FromEntity(selectedOrder);
            if (select != null) orderDto.Select(select.Split(','));
           
            return Ok(orderDto);
        }

        [HttpGet("{id}/baking_goods")]
        public async Task<IActionResult> GetBakingGoodsOfOrderWithQuantities(int id)
        {
            // Make sure order exists
            if (await OrderRepository.GetOrderById(id) == null) return NotFound("Order not found");

            // Gets list of baking goods for an order in a dictionary with the quantity ordered as well
            var bakingGoods = await OrderRepository.ListBakingGoodsForOrderWithQuantities(id);
            
            return Ok(bakingGoods);
        }

        [HttpGet("{id}/packets")]
        public async Task<IActionResult> GetPacketsOfOrder(int id)
        {
            // Make sure order exists
            if (await OrderRepository.GetOrderById(id) == null) return NotFound("Order not found");

            // Get packets of order and transform it into a DTO
            Packet[] packets = await OrderRepository.ListPacketForOrder(id);
            IList<PacketDto> packetDtos = new List<PacketDto>();
            foreach (var packet in packets)
            {
                packetDtos.Add(PacketDto.FromEntity(packet));
            }

            return Ok(packetDtos);
        }
    }
}

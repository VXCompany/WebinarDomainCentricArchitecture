using BusinessLayer;

using Microsoft.AspNetCore.Mvc;
using Web.Dto;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public void PlaatsOrder(OrderDto orderDto)
        {
            var orderService = new OrderService();

            var order = new Order
            {
                Klantnummer = orderDto.Klantnummer,
                ProduktIdentificatie = orderDto.ProduktIdentificatie,
                Aantal = orderDto.Aantal
            };

            orderService.PlaatsOrder(order);
        }
    }
}

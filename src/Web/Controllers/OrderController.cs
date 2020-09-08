using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Web.Dto;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly WinkelDbContext _winkelDbContext;

        public OrderController(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new System.ArgumentNullException(nameof(winkelDbContext));
        }

        [HttpPost]
        public void PlaatsOrder(OrderDto orderDto)
        {
            var orderService = new OrderService(_winkelDbContext);

            orderService.PlaatsOrder(orderDto.KlantIdentificatie, orderDto.ProduktIdentificatie, orderDto.Aantal);
        }
    }
}

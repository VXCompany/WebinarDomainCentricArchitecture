using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using NLayer.Web.Dto;

namespace NLayer.Web.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly WinkelDbContext _winkelDbContext;

        public OrderController(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new System.ArgumentNullException(nameof(winkelDbContext));
        }

        [HttpPost]
        public void Create([FromBody] OrderDto orderDto)
        {
            var orderService = new OrderService(_winkelDbContext);

            orderService.PlaatsOrder(orderDto.KlantIdentificatie, orderDto.ProductIdentificatie, orderDto.Aantal);
        }
    }
}

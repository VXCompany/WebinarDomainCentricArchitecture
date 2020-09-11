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
            var prijsBerekenService = new PrijsBerekenService();

            var orderService = new OrderService(_winkelDbContext, prijsBerekenService);

            orderService.PlaatsOrder(orderDto.KlantIdentificatie, orderDto.ProduktIdentificatie, orderDto.Aantal);
        }
    }
}

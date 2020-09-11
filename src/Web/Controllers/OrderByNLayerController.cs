using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Web.Dto;

namespace Web.Controllers
{
    [ApiController]
    public class OrderByNLayerController : ControllerBase
    {
        private readonly WinkelDbContext _winkelDbContext;

        public OrderByNLayerController(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new System.ArgumentNullException(nameof(winkelDbContext));
        }

        [HttpPost]
        [Route("api/order/createnlayered")]
        public void Create([FromBody] OrderDto orderDto)
        {
            var orderService = new OrderService(_winkelDbContext);

            orderService.PlaatsOrder(orderDto.KlantIdentificatie, orderDto.ProduktIdentificatie, orderDto.Aantal);
        }
    }
}

using System;
using Domain.Services;
using DomainCentric.Web.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DomainCentric.Web.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderMetKortingUsecase _orderMetKortingUsecase;

        public OrderController(IOrderMetKortingUsecase orderMetKortingUsecase)
        {
            _orderMetKortingUsecase = orderMetKortingUsecase ?? throw new ArgumentNullException(nameof(orderMetKortingUsecase));
        }

        [HttpPost]
        public void Create([FromBody] OrderDto orderDto)
        {
            _orderMetKortingUsecase.PlaatsOrder(orderDto.KlantIdentificatie, orderDto.ProductIdentificatie, orderDto.Aantal);
        }
    }
}

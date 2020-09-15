﻿using System;
using Domain.Services;
using DomainCentric.Web.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DomainCentric.Web.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderMetKortingUsecase _orderService;

        public OrderController(IOrderMetKortingUsecase orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpPost]
        public void Create([FromBody] OrderDto orderDto)
        {
            _orderService.PlaatsOrder(orderDto.KlantIdentificatie, orderDto.ProduktIdentificatie, orderDto.Aantal);
        }
    }
}

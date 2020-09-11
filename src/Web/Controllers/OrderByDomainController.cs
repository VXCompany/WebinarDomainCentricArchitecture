using System;
using Microsoft.AspNetCore.Mvc;
using Web.Dto;

namespace Web.Controllers
{
    [ApiController]
    public class OrderByDomainController : ControllerBase
    {
        public OrderByDomainController()
        {
        }

        [HttpPost]
        [Route("api/order/createdomaincentric")]
        public void Create([FromBody] OrderDto orderDto)
        {
            Console.WriteLine("test");
        }
    }
}

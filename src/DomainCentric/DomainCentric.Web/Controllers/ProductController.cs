using System;
using System.Collections.Generic;
using Domain.Model.Producten;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DomainCentric.Web.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IToonProductenUseCase _toonProductenUseCase;

        public ProductController(IToonProductenUseCase toonProductenUseCase)
        {
            _toonProductenUseCase = toonProductenUseCase ?? throw new ArgumentNullException(nameof(toonProductenUseCase));
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _toonProductenUseCase.ToonProducten();
        }
    }
}

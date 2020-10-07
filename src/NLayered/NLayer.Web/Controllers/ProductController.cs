using System.Collections.Generic;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace NLayer.Web.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService ?? throw new System.ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var producten = _productService.GetProducten();

            return producten;
        }
    }
}

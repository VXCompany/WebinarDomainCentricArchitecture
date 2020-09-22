using System.Collections.Generic;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace NLayer.Web.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        private readonly WinkelDbContext _winkelDbContext;
        private readonly ProduktService _produktService;

        public ProduktController(WinkelDbContext winkelDbContext, ProduktService produktService)
        {
            _winkelDbContext = winkelDbContext ?? throw new System.ArgumentNullException(nameof(winkelDbContext));
            _produktService = produktService ?? throw new System.ArgumentNullException(nameof(produktService));
        }

        [HttpGet]
        public IEnumerable<Produkt> Get()
        {
            var produkten = _produktService.GetProducten();

            return produkten;
        }
    }
}

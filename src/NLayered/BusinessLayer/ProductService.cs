using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class ProductService
    {
        private readonly WinkelDbContext _winkelDbContext;

        public ProductService(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new System.ArgumentNullException(nameof(winkelDbContext));
        }
        
        public IEnumerable<Product> GetProducten()
        {
            return _winkelDbContext.Producten.ToList();
        }
    }
}

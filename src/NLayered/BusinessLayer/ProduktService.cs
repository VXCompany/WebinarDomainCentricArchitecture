using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class ProduktService
    {
        private readonly WinkelDbContext _winkelDbContext;

        public ProduktService(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new System.ArgumentNullException(nameof(winkelDbContext));
        }
        
        public IEnumerable<Produkt> GetProducten()
        {
            return _winkelDbContext.Produkten.ToList();
        }
    }
}

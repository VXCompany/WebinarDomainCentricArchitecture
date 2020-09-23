using System;
using System.Linq;
using Domain.Repositories;

namespace Infrastructure.EFSqlStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WinkelDbContext _winkelDbContext;

        public ProductRepository(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new ArgumentNullException(nameof(winkelDbContext));
        }

        public Domain.Model.Producten.Product GetByProductIdentificatie(string productIdentificatie)
        {
            return _winkelDbContext.Producten
                .Where(p => p.ProductIdentificatie.Equals(productIdentificatie))
                .Select(p => new Domain.Model.Producten.Product(p.ProductIdentificatie, p.Prijs))
                .Single();
        }
    }
}

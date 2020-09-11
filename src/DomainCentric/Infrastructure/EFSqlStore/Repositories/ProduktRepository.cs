using System;
using System.Linq;
using Domain.Repositories;

namespace Infrastructure.EFSqlStore.Repositories
{
    public class ProduktRepository : IProduktRepository
    {
        private readonly WinkelDbContext _winkelDbContext;

        public ProduktRepository(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new ArgumentNullException(nameof(winkelDbContext));
        }

        public Domain.Model.Produkten.Produkt GetByProduktIdentificatie(string produktIdentificatie)
        {
            return _winkelDbContext.Produkten
                .Where(p => p.ProduktIdentificatie.Equals(produktIdentificatie))
                .Select(p => new Domain.Model.Produkten.Produkt(p.ProduktIdentificatie, p.Prijs))
                .Single();
        }
    }
}

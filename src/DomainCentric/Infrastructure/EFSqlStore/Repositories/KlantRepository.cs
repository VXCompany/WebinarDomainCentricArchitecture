using System;
using System.Linq;
using Domain.Repositories;

namespace Infrastructure.EFSqlStore.Repositories
{
    public class KlantRepository : IKlantRepository
    {
        private readonly WinkelDbContext _winkelDbContext;

        public KlantRepository(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new ArgumentNullException(nameof(winkelDbContext));
        }

        public Domain.Model.Klanten.Klant GetByKlantIdentificatie(string klantIdentificatie)
        {
            return _winkelDbContext.Klanten
                .Where(k => k.KlantIdentificatie.Equals(klantIdentificatie))
                .Select(k => new Domain.Model.Klanten.Klant(k.KlantIdentificatie))
                .Single();
        }
    }
}

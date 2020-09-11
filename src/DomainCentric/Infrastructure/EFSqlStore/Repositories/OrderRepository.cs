using System;
using System.Linq;
using Domain.Repositories;
using Infrastructure.EFSqlStore.Model;

namespace Infrastructure.EFSqlStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WinkelDbContext _winkelDbContext;

        public OrderRepository(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new ArgumentNullException(nameof(winkelDbContext));
        }

        public void PlaatsOrder(Domain.Model.Orders.Order order)
        {
            var klant = _winkelDbContext.Klanten
                .Single(k => k.KlantIdentificatie.Equals(order.Klant.KlantIdentificatie));

            var produkt = _winkelDbContext.Produkten
                .Single(p => p.ProduktIdentificatie.Equals(order.Produkt.Identificatie));

            _winkelDbContext.Orders.Add(new Order
            {
                Aantal = order.Aantal,
                Klant = klant,
                Produkt = produkt,
                TotaalPrijs = order.TotaalPrijs
            });
        }
    }
}

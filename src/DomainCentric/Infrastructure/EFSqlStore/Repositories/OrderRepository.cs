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

            var product = _winkelDbContext.Producten
                .Single(p => p.ProductIdentificatie.Equals(order.Product.Identificatie));

            _winkelDbContext.Orders.Add(new Order
            {
                Aantal = order.Aantal,
                Klant = klant,
                Product = product,
                TotaalPrijs = order.TotaalPrijs
            });
        }
    }
}

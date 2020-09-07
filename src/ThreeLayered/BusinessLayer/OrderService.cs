using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class OrderService
    {
        private readonly WinkelDbContext _winkelDbContext;

        public OrderService(WinkelDbContext winkelDbContext)
        {
            _winkelDbContext = winkelDbContext ?? throw new System.ArgumentNullException(nameof(winkelDbContext));
        }

        public void PlaatsOrder(Order order)
        {
            var produkt = _winkelDbContext.Produkten.Single(p => p.ProduktIdentificatie.Equals(order.ProduktIdentificatie));

            if (order.Aantal >= 10)
            {
                order.TotaalPrijs = (order.Aantal * produkt.Prijs) * 0.95m;
            }
            else
            {
                order.TotaalPrijs = order.Aantal * produkt.Prijs;
            }

            var klant = _winkelDbContext.Klanten.Single(k => k.KlantIdentificatie.Equals(order.KlantIdentificatie));

            _winkelDbContext.Orders.Add(new DataLayer.Order
            {
                Aantal = order.Aantal,
                Klant = klant,
                Produkt = produkt,
                TotaalPrijs = order.TotaalPrijs
            });

            _winkelDbContext.SaveChanges();
        }
    }
}

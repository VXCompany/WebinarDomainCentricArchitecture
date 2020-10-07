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

        public void PlaatsOrder(string klantIdentificatie, string productIdentificatie, int aantal)
        {
            var product = _winkelDbContext.Producten.Single(p => p.ProductIdentificatie.Equals(productIdentificatie));

            var totaalPrijs = BerekenTotaalPrijs(product.Prijs, aantal, productIdentificatie);

            var klant = _winkelDbContext.Klanten.Single(k => k.KlantIdentificatie.Equals(klantIdentificatie));

            _winkelDbContext.Orders.Add(new Order
            {
                Aantal = aantal,
                Klant = klant,
                Product = product,
                TotaalPrijs = totaalPrijs
            });

            _winkelDbContext.SaveChanges();
        }

        private decimal BerekenTotaalPrijs(decimal stukprijs, int aantal, string productIdentificatie)
        {
            decimal totaalPrijs = 0;

            if (aantal >= 10 && productIdentificatie == "Appel")
            {
                totaalPrijs = (aantal * stukprijs) * 0.95m;
            }
            else
            {
                totaalPrijs = aantal * stukprijs;
            }

            return totaalPrijs;
        }
    }
}

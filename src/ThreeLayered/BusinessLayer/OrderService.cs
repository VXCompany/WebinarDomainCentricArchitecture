using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class OrderService
    {
        private readonly WinkelDbContext _winkelDbContext;
        private readonly PrijsBerekenService _prijsBerekenService;

        public OrderService(WinkelDbContext winkelDbContext, PrijsBerekenService prijsBerekenService)
        {
            _winkelDbContext = winkelDbContext ?? throw new System.ArgumentNullException(nameof(winkelDbContext));
            _prijsBerekenService = prijsBerekenService ?? throw new System.ArgumentNullException(nameof(prijsBerekenService));
        }

        public void PlaatsOrder(string klantIdentificatie, string productIdentificatie, int aantal)
        {
            var produkt = _winkelDbContext.Produkten.Single(p => p.ProduktIdentificatie.Equals(productIdentificatie));

            var totaalPrijs = _prijsBerekenService.BerekenTotaalPrijs(produkt.Prijs, aantal);

            var klant = _winkelDbContext.Klanten.Single(k => k.KlantIdentificatie.Equals(klantIdentificatie));

            _winkelDbContext.Orders.Add(new Order
            {
                Aantal = aantal,
                Klant = klant,
                Produkt = produkt,
                TotaalPrijs = totaalPrijs
            });

            _winkelDbContext.SaveChanges();
        }
    }
}

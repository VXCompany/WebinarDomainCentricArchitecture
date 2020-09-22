﻿using System.Linq;
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
            var produkt = _winkelDbContext.Produkten.Single(p => p.ProduktIdentificatie.Equals(productIdentificatie));

            var totaalPrijs = BerekenTotaalPrijs(produkt.Prijs, aantal);

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

        private decimal BerekenTotaalPrijs(decimal stukprijs, int aantal)
        {
            decimal totaalPrijs = 0;

            if (aantal >= 10)
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

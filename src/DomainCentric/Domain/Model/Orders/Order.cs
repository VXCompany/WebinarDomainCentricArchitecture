using System;
using Domain.Model.Klanten;
using Domain.Model.Produkten;

namespace Domain.Model.Orders
{
    public class Order
    {
        public Order(Klant klant, Produkt produkt)
        {
            Klant = klant ?? throw new ArgumentNullException(nameof(klant));
            Produkt = produkt ?? throw new ArgumentNullException(nameof(produkt));
        }

        public void Plaats(int aantal)
        {
            TotaalPrijs = 0.0m;

            if (aantal >= 10)
            {
                TotaalPrijs = (aantal * Produkt.Prijs) * 0.95m;
            }
            else
            {
                TotaalPrijs = aantal * Produkt.Prijs;
            }

            Aantal = aantal;
        }

        public Klant Klant { get; private set; }

        public Produkt Produkt { get; private set; }

        public decimal TotaalPrijs { get; private set; }

        public int Aantal { get; private set; }
    }
}

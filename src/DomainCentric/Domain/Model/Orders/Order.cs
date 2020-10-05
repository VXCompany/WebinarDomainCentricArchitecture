using System;
using Domain.Model.Klanten;
using Domain.Model.Producten;

namespace Domain.Model.Orders
{
    public class Order
    {
        public Order(Klant klant, Product product)
        {
            Klant = klant ?? throw new ArgumentNullException(nameof(klant));
            Product = product ?? throw new ArgumentNullException(nameof(product));
        }

        public void Plaats(int aantal)
        {
            TotaalPrijs = 0.0m;

            if (aantal >= 10 && Product.Identificatie == "Appel")
            {
                TotaalPrijs = (aantal * Product.Prijs) * 0.95m;
            }
            else
            {
                TotaalPrijs = aantal * Product.Prijs;
            }

            Aantal = aantal;
        }

        public Klant Klant { get; private set; }

        public Product Product { get; private set; }

        public decimal TotaalPrijs { get; private set; }

        public int Aantal { get; private set; }
    }
}

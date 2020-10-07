using Domain.Model.Klanten;
using Domain.Model.Orders;
using Domain.Model.Producten;
using Xunit;

namespace DomainCentric.Tests.Domain
{
    public class OrderTests
    {
        private static Klant DUMMY_KLANT = new Klant("dummy");

        [Fact(DisplayName = "De totaalprijs is gelijk aan het aantal, vermenigvuldigd met de prijs per stuk")]
        public void RegulierePrijs()
        {
            var bananen = new Product("bananen", 0.8m);
            var order = new Order(DUMMY_KLANT, bananen);

            order.Plaats(2);

            Assert.Equal(1.6m, order.TotaalPrijs);
        }

        [Theory(DisplayName = "Als je 10 of meer Appels bestelt, krijg je 5% korting")]
        [InlineData("Appel", 1, 0.6)]
        [InlineData("Appel", 9, 5.4)]
        [InlineData("Appel", 10, 5.7)]
        [InlineData("Appel", 11, 6.27)]
        [InlineData("Banaan", 10, 6.00)]
        public void KortingOpAppels(string productIdentificatie, int amount, decimal expectedTotal)
        {
            var product = new Product(productIdentificatie, 0.6m);
            var order = new Order(DUMMY_KLANT, product);

            order.Plaats(amount);

            Assert.Equal(expectedTotal, order.TotaalPrijs);
        }
    }
}

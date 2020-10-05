using System.Linq;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace NLayered.Tests.BusinessLayer
{
    public class OrderServiceTests
    {
        private static Product BANAAN = new Product()
        {
            ProductIdentificatie = "Banaan",
            Prijs = 0.6m
        };

        private static Klant KLANT = new Klant()
        {
            KlantIdentificatie = "vx"
        };

        private readonly WinkelDbContext _winkelDbContext;

        public OrderServiceTests()
        {
            var options = new DbContextOptionsBuilder<WinkelDbContext>()
                            .UseInMemoryDatabase(databaseName: "Winkel")
                            .Options;

            _winkelDbContext = new WinkelDbContext(options);
            _winkelDbContext.Database.EnsureDeleted();
        }

        [Fact(DisplayName = "De totaalprijs is het aantal bestelde producten, vermenigvuldigd met de prijs per stuk")]
        public void ReguliereTotaalPrijs()
        {
            _winkelDbContext.Producten.Add(BANAAN);
            _winkelDbContext.Klanten.Add(KLANT);
            _winkelDbContext.SaveChanges();
            var orderService = new OrderService(_winkelDbContext);

            orderService.PlaatsOrder("vx", "Banaan", 2);

            var order = _winkelDbContext.Orders.First();
            Assert.Equal(1.2m, order.TotaalPrijs);
        }
    }
}

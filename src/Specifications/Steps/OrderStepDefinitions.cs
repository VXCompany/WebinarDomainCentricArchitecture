using System.Linq;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NLayer.Web.Controllers;
using NLayer.Web.Dto;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Specifications.Steps
{
    [Binding]
    public class OrderStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WinkelDbContext _winkelDbContext;

        public OrderStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new System.ArgumentNullException(nameof(scenarioContext));

            var options = new DbContextOptionsBuilder<WinkelDbContext>()
                            .UseInMemoryDatabase(databaseName: "Winkel")
                            .Options;

            _winkelDbContext = new WinkelDbContext(options);
        }

        [BeforeScenario]
        public void InitTables()
        {
            _winkelDbContext.Database.EnsureDeleted();
        }

        [Given(@"de volgende klanten")]
        public void GegevenDeVolgendeKlanten(Table table)
        {
            var klanten = table.CreateSet<Klant>();

            _winkelDbContext.Klanten.AddRange(klanten);

            _winkelDbContext.SaveChanges();
        }

        [Given(@"de volgende produkten")]
        public void GegevenDeVolgendeProdukten(Table table)
        {
            var produkten = table.CreateSet<Produkt>();

            _winkelDbContext.Produkten.AddRange(produkten);

            _winkelDbContext.SaveChanges();
        }

        [Given(@"klant '(.*)'")]
        public void GegevenKlant(string klantIdentificatie)
        {
            _scenarioContext["klantIdentificatie"] = klantIdentificatie;
        }

        [When(@"ik '(.*)' aantal van het produkt '(.*)' bestel")]
        public void AlsIkAantalVanHetProduktBestel(int aantal, string produktIdentificatie)
        {
            _scenarioContext["produktIdentificatie"] = produktIdentificatie;
            _scenarioContext["aantal"] = aantal;

            var orderDto = new OrderDto
            {
                KlantIdentificatie = "KL123",
                ProduktIdentificatie = "Appel",
                Aantal = (int)_scenarioContext["aantal"],
            };

            var controller = new OrderController(_winkelDbContext);

            controller.Create(orderDto);
        }

        [Then(@"wordt het totaalbedrag '(.*)'")]
        public void DanWordtHetTotaalbedrag(decimal totaalbedrag)
        {
            var klantIdentificatie = _scenarioContext["klantIdentificatie"];

            var order = _winkelDbContext.Orders.Single(o => o.Klant.KlantIdentificatie.Equals(klantIdentificatie));

            Assert.Equal(totaalbedrag, order.TotaalPrijs);
        }
    }
}

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

        [Given(@"de volgende producten")]
        public void GegevenDeVolgendeProducten(Table table)
        {
            var producten = table.CreateSet<Product>();

            _winkelDbContext.Producten.AddRange(producten);

            _winkelDbContext.SaveChanges();
        }

        [Given(@"klant '(.*)'")]
        public void GegevenKlant(string klantIdentificatie)
        {
            _scenarioContext["klantIdentificatie"] = klantIdentificatie;
        }

        [When(@"ik '(.*)' aantal van het product '(.*)' bestel")]
        public void AlsIkAantalVanHetProductBestel(int aantal, string ProductIdentificatie)
        {
            _scenarioContext["ProductIdentificatie"] = ProductIdentificatie;
            _scenarioContext["aantal"] = aantal;

            var orderDto = new OrderDto
            {
                KlantIdentificatie = "KL123",
                ProductIdentificatie = "Appel",
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

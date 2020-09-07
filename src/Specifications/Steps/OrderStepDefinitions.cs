using DataLayer;
using Microsoft.EntityFrameworkCore;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Web.Controllers;
using Web.Dto;

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

            // Insert seed data into the database using one instance of the context
            _winkelDbContext = new WinkelDbContext(options);
        }

        [Given(@"'(.*)' afgenomen produkten")]
        public void GegevenAfgenomenProdukten(int aantal)
        {
            _scenarioContext["aantal"] = aantal;
        }

        [When(@"ik produkten bestel")]
        public void AlsIkProduktenBestel()
        {
            var orderDto = new OrderDto
            {
                KlantIdentificatie = "KL123",
                ProduktIdentificatie = "Appel",
                Aantal = (int)_scenarioContext["aantal"],
            };

            var controller = new OrderController(_winkelDbContext);

            controller.PlaatsOrder(orderDto);
        }

        [Then(@"wordt er '(.*)' procent korting gegeven")]
        public void DanWordtErProcentKortingGegeven(int korting)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"klant '(.*)'")]
        public void GegevenKlant(string klantIdentificatie)
        {
            _winkelDbContext.Klanten.Add(new Klant
            {
                KlantIdentificatie = klantIdentificatie
            });

            _winkelDbContext.SaveChanges();
        }

        [Given(@"de volgende produkten")]
        public void GegevenDeVolgendeProdukten(Table table)
        {
            var produkten = table.CreateSet<Produkt>();

            _winkelDbContext.Produkten.AddRange(produkten);

            _winkelDbContext.SaveChanges();
        }
    }
}

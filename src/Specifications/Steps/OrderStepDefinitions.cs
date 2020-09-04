using TechTalk.SpecFlow;
using Web.Controllers;
using Web.Dto;

namespace Specifications.Steps
{
    [Binding]
    public class OrderStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public OrderStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new System.ArgumentNullException(nameof(scenarioContext));
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
                Klantnummer = 123,
                ProduktIdentificatie = "Appel",
                Aantal = (int)_scenarioContext["aantal"],
            };

            var controller = new OrderController();

            controller.PlaatsOrder(orderDto);
        }

        [Then(@"wordt er '(.*)' procent korting gegeven")]
        public void DanWordtErProcentKortingGegeven(int korting)
        {
            ScenarioContext.Current.Pending();
        }
    }
}

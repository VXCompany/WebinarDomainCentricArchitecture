using TechTalk.SpecFlow;

namespace Specifications.Steps
{
    [Binding]
    public class OrderStepDefinitions
    {
        [Given(@"'(.*)' afgenomen produkten")]
        public void GegevenAfgenomenProdukten(int aantal)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"ik produkten bestel")]
        public void AlsIkProduktenBestel()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"wordt er '(.*)' procent korting gegeven")]
        public void DanWordtErProcentKortingGegeven(int korting)
        {
            ScenarioContext.Current.Pending();
        }
    }
}

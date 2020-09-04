using TechTalk.SpecFlow;

namespace Specifications.Steps
{
    [Binding]
    public sealed class OrderStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public OrderStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}

using TechTalk.SpecFlow;

namespace CukeinatorAcceptanceTests.StepDefinitions
{
    [Binding]
    public class FruitSoldier
    {
        private readonly ScenarioContext scenarioContext;

        public FruitSoldier(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("Fruit soldier has health")]
        public void GivenFruitSoldierHasHealth()
        {
            scenarioContext.Pending();
        }

        [When("Fruit soldier is attacked")]
        public void WhenFruitSoldierIsAttacked()
        {
            scenarioContext.Pending();
        }

        [Then("Fruit soldier will take damage to health")]
        public void ThenFruitSoldierWillTakeDamageToHealth()
        {
            scenarioContext.Pending();
        }
    }
}
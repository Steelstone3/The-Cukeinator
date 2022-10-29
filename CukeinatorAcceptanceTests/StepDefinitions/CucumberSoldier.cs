using TechTalk.SpecFlow;

namespace CukeinatorAcceptanceTests.StepDefinitions
{
    [Binding]
    public class CucumberSoldier
    {
        private readonly ScenarioContext scenarioContext;

        public CucumberSoldier(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("Cucumber soldier has shields")]
        public void GivenCucumberSoldierHasShields()
        {
            scenarioContext.Pending();
        }

        [Given("Cucumber soldier has depleted shields")]
        public void GivenCucumberSoldierHasDepletedShields()
        {
            scenarioContext.Pending();
        }

        [When("Cucumber soldier is attacked")]
        public void WhenCucumberSoldierIsAttacked()
        {
            scenarioContext.Pending();
        }

        [Then("Cucumber soldier will take damage to shields")]
        public void ThenCucumberSoldierWillTakeDamageToShields()
        {
            scenarioContext.Pending();
        }


        [Then("Cucumber soldier will take damage to health")]
        public void ThenCucumberSoldierWillTakeDamageToHealth()
        {
            scenarioContext.Pending();
        }

        [Then("Cucumber soldier will take no damage to health")]
        public void ThenCucumberSoldierWillTakeNoDamageToHealth()
        {
            scenarioContext.Pending();
        }
    }
}
using Cukeinator.Models;
using TechTalk.SpecFlow;
using Xunit;

namespace CukeinatorAcceptanceTests.StepDefinitions
{
    [Binding]
    public class FruitSoldierSteps
    {
        private const string SOLDIER = "Soldier";
        private const string WOUNDED_SOLDIER = "Wounded Soldier";

        private const byte DAMAGE = 50;
        private const byte REMAINING_HEALTH = 60;

        private readonly ScenarioContext scenarioContext;

        public FruitSoldierSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("Fruit soldier has health")]
        public void GivenFruitSoldierHasHealth()
        {
            ISoldier soldier = new FruitSoldier();
            scenarioContext.Add(SOLDIER, soldier);
        }

        [When("Fruit soldier's health is attacked")]
        public void WhenFruitSoldiersHealthIsAttacked()
        {
            var soldier = scenarioContext.Get<ISoldier>(SOLDIER);
            soldier.TakeHealthDamage(DAMAGE);

            scenarioContext.Add(WOUNDED_SOLDIER, soldier);
        }

        [Then("Fruit soldier will take damage to health")]
        public void ThenFruitSoldierWillTakeDamageToHealth()
        {
            var soldier = scenarioContext.Get<ISoldier>(WOUNDED_SOLDIER);
            Assert.Equal(REMAINING_HEALTH, soldier.Health);
        }
    }
}
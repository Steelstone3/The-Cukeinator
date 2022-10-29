using Cukeinator.Controllers;
using Cukeinator.Models;
using Moq;
using Xunit;

namespace CukeinatorTests.Controllers
{
    public class GameControllerShould
    {
        private readonly IGameController gameController = new GameController();

        [Fact]
        public void RunPlayerTurn()
        {
            // Given
            ICucumberSoldier attackingSolider = new CucumberSoldier();
            Mock<ISoldier> defendingSoldier = new Mock<ISoldier>();
            defendingSoldier.Setup(ds => ds.TakeHealthDamage(attackingSolider.Attack));

            // When
            gameController.PlayerTurn(attackingSolider, defendingSoldier.Object);

            // Then
            defendingSoldier.VerifyAll();
        }

        [Fact]
        public void RunComputerTurn()
        {
            // Given
            ISoldier attackingSoldier = new FruitSoldier();
            Mock<ICucumberSoldier> defendingSoldier = new Mock<ICucumberSoldier>();
            defendingSoldier.Setup(ds => ds.TakeShieldDamage(attackingSoldier.Attack));
            defendingSoldier.Setup(ds => ds.TakeHealthDamage(attackingSoldier.Attack));

            // When
            gameController.ComputerTurn(attackingSoldier, defendingSoldier.Object);

            // Then
            defendingSoldier.VerifyAll();
        }
    }
}
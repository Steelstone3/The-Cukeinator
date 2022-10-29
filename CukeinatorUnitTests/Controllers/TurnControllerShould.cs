using Cukeinator.Controllers;
using Cukeinator.Models;
using Moq;
using Xunit;

namespace CukeinatorTests.Controllers
{
    public class TurnControllerShould
    {
        private readonly ITurnController turnController = new TurnController();

        [Fact]
        public void RunPlayerTurn()
        {
            // Given
            ICucumberSoldier attackingSolider = new CucumberSoldier();
            Mock<ISoldier> mockDefendingSoldier = new Mock<ISoldier>();
            mockDefendingSoldier.Setup(ds => ds.TakeHealthDamage(attackingSolider.Attack));

            // When
            turnController.PlayerTurn(attackingSolider, mockDefendingSoldier.Object);

            // Then
            mockDefendingSoldier.VerifyAll();
        }

        [Fact]
        public void RunComputerTurn()
        {
            // Given
            ISoldier attackingSoldier = new FruitSoldier();
            Mock<ICucumberSoldier> mockDefendingSoldier = new Mock<ICucumberSoldier>();
            mockDefendingSoldier.Setup(ds => ds.TakeShieldDamage(attackingSoldier.Attack));
            mockDefendingSoldier.Setup(ds => ds.TakeHealthDamage(attackingSoldier.Attack));

            // When
            turnController.ComputerTurn(attackingSoldier, mockDefendingSoldier.Object);

            // Then
            mockDefendingSoldier.VerifyAll();
        }
    }
}
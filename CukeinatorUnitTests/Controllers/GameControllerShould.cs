using Cukeinator.Controllers;
using Cukeinator.Models;
using Cukeinator.Presenters;
using Moq;
using Xunit;

namespace CukeinatorUnitTests.Controllers
{
    public class GameControllerShould
    {
        private ICucumberSoldier playerSoldier = new CucumberSoldier();
        private ISoldier computerSoldier = new FruitSoldier();
        Mock<IPresenter> mockPresenter = new();
        Mock<ITurnController> stubTurnController = new();

        public GameControllerShould()
        {
            mockPresenter.Setup(p => p.Print($"Player soldier does {playerSoldier.Attack} to computer soldier."));
            mockPresenter.Setup(p => p.Print($"Computer soldier does {computerSoldier.Attack} to player soldier."));   
            mockPresenter.Setup(p => p.Print($"| Player soldier | Shields: {playerSoldier.Shields} | Health: {playerSoldier.Health} |\n| Computer soldier | Health: {computerSoldier.Health} |"));
        }

        [Fact]
        public void RunCombatTurns()
        {
            // Given
            stubTurnController.Setup(tc => tc.PlayerTurn(playerSoldier, computerSoldier)).Returns(false);
            stubTurnController.Setup(tc => tc.ComputerTurn(computerSoldier, playerSoldier)).Returns(false);
            IGameController gameController = new GameController(mockPresenter.Object,stubTurnController.Object);

            // When
            gameController.RunCombat(playerSoldier, computerSoldier);

            // Then
            mockPresenter.VerifyAll();
            stubTurnController.VerifyAll();
        }
    }
}
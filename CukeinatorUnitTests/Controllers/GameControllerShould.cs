using Cukeinator.Controllers;
using Cukeinator.Models;
using Cukeinator.Presenters;
using Moq;
using Xunit;

namespace CukeinatorUnitTests.Controllers
{
    public class GameControllerShould
    {
        private readonly Mock<ICucumberSoldier> stubPlayerSoldier = new();
        private readonly Mock<ISoldier> stubComputerSoldier = new();
        private readonly Mock<IPresenter> mockPresenter = new();
        private readonly Mock<ITurnController> stubTurnController = new();
        private string PlayerSoldierAttackMessage => $"Player soldier does {stubPlayerSoldier.Object.Attack} to computer soldier.";
        private string ComputerSoldierAttackMessage => $"Computer soldier does {stubComputerSoldier.Object.Attack} to player soldier.";
        private string StatusMessage => $"| Player soldier | Shields: {stubPlayerSoldier.Object.Shields} | Health: {stubPlayerSoldier.Object.Health} |\n| Computer soldier | Health: {stubComputerSoldier.Object.Health} |";
        private IGameController gameController;

        public GameControllerShould()
        {
            stubPlayerSoldier.Setup(ps => ps.IsAlive).Returns(true);
            stubComputerSoldier.Setup(ps => ps.IsAlive).Returns(true);

            mockPresenter.Setup(p => p.Print(PlayerSoldierAttackMessage));
            mockPresenter.Setup(p => p.Print(ComputerSoldierAttackMessage));
            mockPresenter.Setup(p => p.Print(StatusMessage));

            stubTurnController.Setup(tc => tc.PlayerTurn(stubPlayerSoldier.Object, stubComputerSoldier.Object)).Returns(true);
            stubTurnController.Setup(tc => tc.ComputerTurn(stubComputerSoldier.Object, stubPlayerSoldier.Object)).Returns(false);

            gameController = new GameController(mockPresenter.Object, stubTurnController.Object);
        }

        [Fact]
        public void RunPlayersTurn()
        {
            // Given
            stubTurnController.Setup(tc => tc.ComputerTurn(stubComputerSoldier.Object, stubPlayerSoldier.Object)).Returns(false);
            gameController = new GameController(mockPresenter.Object, stubTurnController.Object);

            // When
            gameController.RunCombat(stubPlayerSoldier.Object, stubComputerSoldier.Object);

            // Then
            mockPresenter.VerifyAll();
            stubTurnController.VerifyAll();
        }

        [Fact]
        public void RunPlayersLastTurn()
        {
            // Given
            stubComputerSoldier.Setup(cs => cs.IsAlive).Returns(false);
            stubTurnController.Setup(tc => tc.ComputerTurn(stubComputerSoldier.Object, stubPlayerSoldier.Object)).Returns(false);
            gameController = new GameController(mockPresenter.Object, stubTurnController.Object);

            // When
            gameController.RunCombat(stubPlayerSoldier.Object, stubComputerSoldier.Object);

            // Then
            mockPresenter.Verify(p => p.Print(PlayerSoldierAttackMessage), Times.Never);
            mockPresenter.Verify(p => p.Print(ComputerSoldierAttackMessage));
            mockPresenter.Verify(p => p.Print(StatusMessage));
            stubTurnController.Verify(tc => tc.PlayerTurn(stubPlayerSoldier.Object, stubComputerSoldier.Object), Times.Never);
            stubTurnController.Verify(tc => tc.ComputerTurn(stubComputerSoldier.Object, stubPlayerSoldier.Object));
        }

        [Fact]
        public void RunComputersTurn()
        {
            // Given
            stubTurnController.Setup(tc => tc.PlayerTurn(stubPlayerSoldier.Object, stubComputerSoldier.Object)).Returns(false);
            gameController = new GameController(mockPresenter.Object, stubTurnController.Object);

            // When
            gameController.RunCombat(stubPlayerSoldier.Object, stubComputerSoldier.Object);

            // Then
            mockPresenter.Verify(p => p.Print(PlayerSoldierAttackMessage));
            mockPresenter.Verify(p => p.Print(ComputerSoldierAttackMessage), Times.Never);
            mockPresenter.Verify(p => p.Print(StatusMessage));
            stubTurnController.Verify(tc => tc.PlayerTurn(stubPlayerSoldier.Object, stubComputerSoldier.Object));
            stubTurnController.Verify(tc => tc.ComputerTurn(stubComputerSoldier.Object, stubPlayerSoldier.Object), Times.Never);
        }

        [Fact]
        public void RunComputersLastTurn()
        {
            // Given
            stubPlayerSoldier.Setup(ps => ps.IsAlive).Returns(false);
            stubTurnController.Setup(tc => tc.PlayerTurn(stubPlayerSoldier.Object, stubComputerSoldier.Object)).Returns(false);
            gameController = new GameController(mockPresenter.Object, stubTurnController.Object);

            // When
            gameController.RunCombat(stubPlayerSoldier.Object, stubComputerSoldier.Object);

            // Then
            mockPresenter.Verify(p => p.Print(PlayerSoldierAttackMessage));
            mockPresenter.Verify(p => p.Print(ComputerSoldierAttackMessage), Times.Never);
            mockPresenter.Verify(p => p.Print(StatusMessage));
            stubTurnController.Verify(tc => tc.PlayerTurn(stubPlayerSoldier.Object, stubComputerSoldier.Object));
            stubTurnController.Verify(tc => tc.ComputerTurn(stubComputerSoldier.Object, stubPlayerSoldier.Object), Times.Never);
        }

    }
}
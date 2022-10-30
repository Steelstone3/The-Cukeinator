using Cukeinator.Controllers;
using Cukeinator.Models;
using Moq;
using Xunit;

namespace CukeinatorTests.Controllers
{
    public class TurnControllerShould
    {
        private ICucumberSoldier playerSoldier = new CucumberSoldier();
        private ISoldier computerSoldier = new FruitSoldier();
        private Mock<ISoldier> stubDefendingComputerSoldier = new();
        private Mock<ICucumberSoldier> stubDefendingPlayerSoldier = new();
        private readonly ITurnController turnController = new TurnController();

        public TurnControllerShould()
        {
            stubDefendingPlayerSoldier.Setup(ds => ds.IsAlive).Returns(true);
            stubDefendingPlayerSoldier.Setup(ds => ds.TakeShieldDamage(computerSoldier.Attack));
            stubDefendingPlayerSoldier.Setup(ds => ds.TakeHealthDamage(computerSoldier.Attack));

            stubDefendingComputerSoldier.Setup(ds => ds.IsAlive).Returns(true);
            stubDefendingComputerSoldier.Setup(ds => ds.TakeHealthDamage(playerSoldier.Attack));
        }

        [Fact]
        public void RunPlayerTurn()
        {
            // When
            bool isInCombat = turnController.PlayerTurn(playerSoldier, stubDefendingComputerSoldier.Object);

            // Then
            Assert.True(isInCombat);
            stubDefendingComputerSoldier.VerifyAll();
        }

        [Fact]
        public void AllowPlayerSoldierToKillComputerSoldier()
        {
            // When
            stubDefendingComputerSoldier.Setup(ds => ds.IsAlive).Returns(false);
            bool isInCombat = turnController.PlayerTurn(playerSoldier, stubDefendingComputerSoldier.Object);

            // Then
            Assert.False(isInCombat);
            stubDefendingComputerSoldier.VerifyAll();
        }

        [Fact]
        public void NotAllowDeadPlayerSoldierToAttackComputerSoldier()
        {
            // Given
            Mock<ICucumberSoldier> stubAttackingSoldier = new();
            stubAttackingSoldier.Setup(ats => ats.IsAlive).Returns(false);

            // When
            bool isInCombat = turnController.PlayerTurn(stubAttackingSoldier.Object, stubDefendingComputerSoldier.Object);

            // Then
            Assert.False(isInCombat);
            stubDefendingComputerSoldier.Verify(ds => ds.TakeHealthDamage(stubAttackingSoldier.Object.Attack), Times.Never);
        }

        [Fact]
        public void RunComputerTurn()
        {
            // When
            bool isInCombat = turnController.ComputerTurn(computerSoldier, stubDefendingPlayerSoldier.Object);

            // Then
            Assert.True(isInCombat);
            stubDefendingPlayerSoldier.VerifyAll();
        }

        [Fact]
        public void AllowComputerSoldierToKillPlayerSoldier()
        {
            // When
            stubDefendingPlayerSoldier.Setup(ds => ds.IsAlive).Returns(false);
            bool isInCombat = turnController.ComputerTurn(computerSoldier, stubDefendingPlayerSoldier.Object);

            // Then
            Assert.False(isInCombat);
            stubDefendingPlayerSoldier.VerifyAll();
        }

        [Fact]
        public void NotAllowDeadComputerSoldierToAttackPlayerSoldier()
        {
            // Given
            Mock<ISoldier> stubAttackingSoldier = new();
            stubAttackingSoldier.Setup(ats => ats.IsAlive).Returns(false);

            // When
            bool isInCombat = turnController.ComputerTurn(stubAttackingSoldier.Object, stubDefendingPlayerSoldier.Object);

            // Then
            Assert.False(isInCombat);
            stubDefendingComputerSoldier.Verify(ds => ds.TakeHealthDamage(stubAttackingSoldier.Object.Attack), Times.Never);
        }

        // [Fact]
        // public void AllowPlayerSoldierToDefeatComputerSoldier()
        // {
        //     // Given
        //     Mock<ISoldier> stubDeadComputerSoldier = new();
        //     // stubDeadComputerSoldier.Setup(cs => cs.Health).Returns(0);
        //     // stubDeadComputerSoldier.Setup(ds => ds.IsAlive).Returns(false);
        //     stubDeadComputerSoldier.Setup(ds => ds.TakeHealthDamage(playerSoldier.Attack));

        //     // When
        //     turnController.PlayerTurn(playerSoldier, stubDeadComputerSoldier.Object);

        //     // Then
        //     stubDeadComputerSoldier.Verify(cs => cs.TakeHealthDamage(playerSoldier.Attack), Times.Never);
        // }

        // [Fact]
        // public void AllowComputerSoldierToDefeatPlayerSoldier()
        // {
        //     // Given
        //     Mock<ICucumberSoldier> stubDeadPlayerSoldier = new();
        //     stubDeadPlayerSoldier.Setup(cs => cs.Health).Returns(0);
        //     stubDeadPlayerSoldier.Setup(ds => ds.IsAlive).Returns(false);

        //     // When
        //     turnController.ComputerTurn(computerSoldier, stubDeadPlayerSoldier.Object);

        //     // Then
        //     stubDeadPlayerSoldier.Verify(cs => cs.TakeShieldDamage(playerSoldier.Attack), Times.Never);
        //     stubDeadPlayerSoldier.Verify(cs => cs.TakeHealthDamage(playerSoldier.Attack), Times.Never);
        // }
    }
}
using Cukeinator.Models;
using Xunit;

namespace CukeinatorTests.Models
{
    public class CucumberSoldierShould
    {
        [Fact]
        public void Construct()
        {
            // Given
            ICucumberSoldier soldier = new CucumberSoldier();

            // Then
            Assert.Equal(100, soldier.Shields);
            Assert.Equal(100, soldier.Health);
            Assert.Equal(25, soldier.Attack);
            Assert.Equal(50, soldier.SpecialAttack);
            Assert.Equal(10, soldier.Defense);
        }

        [Theory]
        [InlineData(110)]
        [InlineData(111)]
        [InlineData(150)]
        [InlineData(200)]
        public void TakeExtremeShieldDamage(byte damage)
        {
            //Given
            ICucumberSoldier soldier = new CucumberSoldier();

            //When
            soldier.TakeShieldDamage(damage);

            //Then
            Assert.Equal(0, soldier.Shields);
        }
    }
}
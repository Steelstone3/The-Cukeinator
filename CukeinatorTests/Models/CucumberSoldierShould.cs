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
        [InlineData(60, 50)]
        [InlineData(40, 70)]
        [InlineData(30, 80)]
        [InlineData(20, 90)]
        [InlineData(10, 100)]
        [InlineData(5, 100)]
        public void TakeShieldDamage(byte damage, byte shields)
        {
            //Given
            ICucumberSoldier soldier = new CucumberSoldier();

            //When
            soldier.TakeShieldDamage(damage);

            //Then
            Assert.Equal(shields, soldier.Shields);
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

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(110)]
        [InlineData(200)]
        public void TakeNoHealthDamageWhilstShieldsAreFunctional(byte damage)
        {
            //Given
            ICucumberSoldier soldier = new CucumberSoldier();

            //When
            soldier.TakeHealthDamage(damage);

            //Then
            Assert.Equal(100, soldier.Health);
        }
    }
}
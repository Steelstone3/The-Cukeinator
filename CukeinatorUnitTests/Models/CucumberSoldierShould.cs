using Cukeinator.Models;
using Xunit;

namespace CukeinatorTests.Models
{
    public class CucumberSoldierShould
    {
        private ICucumberSoldier soldier = new CucumberSoldier();

        [Fact]
        public void Construct()
        {
            // Then
            Assert.Equal(100, soldier.Shields);
            Assert.Equal(100, soldier.Health);
            Assert.Equal(25, soldier.Attack);
            Assert.Equal(50, soldier.SpecialAttack);
            Assert.Equal(10, soldier.Defense);
            Assert.True(soldier.IsAlive);
        }

        [Theory]
        [InlineData(5, 100)]
        [InlineData(10, 100)]
        [InlineData(50, 60)]
        [InlineData(100, 10)]
        [InlineData(110, 0)]
        [InlineData(200, 0)]
        public void TakeHealthDamage(byte damage, byte health)
        {
            //When
            soldier.TakeShieldDamage(byte.MaxValue);
            soldier.TakeHealthDamage(damage);

            //Then
            Assert.Equal(health, soldier.Health);
        }

        [Theory]
        [InlineData(60, 50)]
        [InlineData(40, 70)]
        [InlineData(30, 80)]
        [InlineData(20, 90)]
        [InlineData(10, 100)]
        [InlineData(5, 100)]
        [InlineData(110, 0)]
        [InlineData(111, 0)]
        [InlineData(150, 0)]
        [InlineData(200, 0)]
        public void TakeShieldDamage(byte damage, byte shields)
        {
            //When
            soldier.TakeShieldDamage(damage);

            //Then
            Assert.Equal(shields, soldier.Shields);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(110)]
        [InlineData(200)]
        public void TakeNoHealthDamageWhilstShieldsAreFunctional(byte damage)
        {
            //When
            soldier.TakeHealthDamage(damage);

            //Then
            Assert.Equal(100, soldier.Health);
        }

        [Fact]
        public void DieWhenHealthIsZero()
        {
            // When
            soldier.TakeShieldDamage(byte.MaxValue);
            soldier.TakeHealthDamage(byte.MaxValue);

            // Then
            Assert.False(soldier.IsAlive);
        }
    }
}
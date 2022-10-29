using Cukeinator.Models;
using Xunit;

namespace CukeinatorTests.Models
{
    public class FruitSoldierShould
    {
        [Fact]
        public void Construct()
        {
            // Given
            ISoldier soldier = new FruitSoldier();

            // Then
            Assert.Equal(100, soldier.Health);
            Assert.Equal(25, soldier.Attack);
            Assert.Equal(10, soldier.Defense);
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
        public void TakeHealthDamage(byte damage, byte health)
        {
            //Given
            ISoldier soldier = new FruitSoldier();

            //When
            soldier.TakeHealthDamage(damage);

            //Then
            Assert.Equal(health, soldier.Health);
        }
    }
}
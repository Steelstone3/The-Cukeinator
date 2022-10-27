using Cukeinator.Models;
using Xunit;

namespace CukeinatorTests.Models
{
    public class SoldierShould
    {
        [Fact]
        public void Construct()
        {
            // Given
            ISoldier soldier = new Soldier();

            // Then
            Assert.Equal(100, soldier.Health);
            Assert.Equal(25, soldier.Attack);
            Assert.Equal(10, soldier.Defense);
        }

        [Theory]
        [InlineData(110)]
        [InlineData(111)]
        [InlineData(150)]
        [InlineData(200)]
        public void TakeExtremeHealthDamage(byte damage)
        {
            //Given
            ISoldier soldier = new Soldier();

            //When
            soldier.TakeHealthDamage(damage);

            //Then
            Assert.Equal(0, soldier.Health);
        }
    }
}
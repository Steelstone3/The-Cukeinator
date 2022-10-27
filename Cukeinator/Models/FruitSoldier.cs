namespace Cukeinator.Models
{
    public class FruitSoldier : Soldier
    {
        public override void TakeHealthDamage(byte damage)
        {
            if (damage < Defense)
            {
                return;
            }
            else if (damage - Defense >= Health)
            {
                Health = 0;
            }
            else
            {
                Health -= (byte)(damage - Defense);
            }
        }
    }
}
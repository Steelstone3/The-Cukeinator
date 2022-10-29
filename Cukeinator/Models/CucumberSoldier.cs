namespace Cukeinator.Models
{
    public class CucumberSoldier : Soldier, ICucumberSoldier
    {
        public byte Shields { get; private set; } = 100;
        public byte SpecialAttack => 50;

        public override void TakeHealthDamage(byte damage)
        {
            if(damage < Defense || Shields > 0)
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

        public void TakeShieldDamage(byte damage)
        {
            if(damage < Defense)
            {
                return;
            }
            else if (damage - Defense >= Shields)
            {
                Shields = 0;
            }
            else
            {
                Shields -= (byte)(damage - Defense);
            }
        }
    }
}
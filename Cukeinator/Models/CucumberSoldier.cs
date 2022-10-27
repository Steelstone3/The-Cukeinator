namespace Cukeinator.Models
{
    public class CucumberSoldier : Soldier, ICucumberSoldier
    {
        public byte Shields { get; private set; } = 100;
        public byte SpecialAttack => 50;

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
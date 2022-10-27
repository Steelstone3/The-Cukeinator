using System.Collections.Generic;

namespace Cukeinator.Models
{
    public class Soldier : ISoldier
    {
        public byte Health { get; private set; } = 100;
        public byte Attack => 25;
        public byte Defense => 10;

        public void TakeHealthDamage(byte damage)
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
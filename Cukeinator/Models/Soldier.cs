namespace Cukeinator.Models
{
    public abstract class Soldier : ISoldier
    {
        public byte Health { get; protected set; } = 100;
        public byte Attack => 25;
        public byte Defense => 10;
        public bool IsAlive => Health != 0;
        public abstract void TakeHealthDamage(byte damage);
    }
}
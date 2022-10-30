namespace Cukeinator.Models
{
    public interface ISoldier
    {
        byte Health { get; }
        byte Attack { get; }
        byte Defense { get; }
        bool IsAlive { get; }
        
        void TakeHealthDamage(byte damage);
    }
}
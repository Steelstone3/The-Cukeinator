namespace Cukeinator.Models
{
    public interface ICucumberSoldier : ISoldier
    {
        byte Shields { get; }
        byte SpecialAttack { get; }
        void TakeShieldDamage(byte damage);
    }
}
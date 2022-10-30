using Cukeinator.Models;

namespace Cukeinator.Controllers
{
    public class TurnController : ITurnController
    {
        public bool PlayerTurn(ICucumberSoldier attackingSoldier, ISoldier defendingSoldier)
        {
            if (attackingSoldier.IsAlive)
            {
                defendingSoldier.TakeHealthDamage(attackingSoldier.Attack);
                
                return defendingSoldier.IsAlive;
            }

            return attackingSoldier.IsAlive;
        }

        public bool ComputerTurn(ISoldier attackingSoldier, ICucumberSoldier defendingSoldier)
        {
            if (attackingSoldier.IsAlive)
            {
                defendingSoldier.TakeHealthDamage(attackingSoldier.Attack);
                defendingSoldier.TakeShieldDamage(attackingSoldier.Attack);
                
                return defendingSoldier.IsAlive;
            }

            return attackingSoldier.IsAlive;
        }
    }
}
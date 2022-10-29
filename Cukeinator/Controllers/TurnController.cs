using Cukeinator.Models;

namespace Cukeinator.Controllers
{
    public class TurnController : ITurnController
    {
        public bool PlayerTurn(ICucumberSoldier attackingSolider, ISoldier defendingSoldier)
        {
            defendingSoldier.TakeHealthDamage(attackingSolider.Attack);

            return false;
        }

        public bool ComputerTurn(ISoldier attackingSoldier, ICucumberSoldier defendingSoldier)
        {
            defendingSoldier.TakeShieldDamage(attackingSoldier.Attack);
            defendingSoldier.TakeHealthDamage(attackingSoldier.Attack);

            return false;
        }
    }
}
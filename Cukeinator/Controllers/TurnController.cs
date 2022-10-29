using Cukeinator.Models;

namespace Cukeinator.Controllers
{
    public class TurnController : ITurnController
    {
        public void PlayerTurn(ICucumberSoldier attackingSolider, ISoldier defendingSoldier)
        {
            defendingSoldier.TakeHealthDamage(attackingSolider.Attack);
        }

        public void ComputerTurn(ISoldier attackingSoldier, ICucumberSoldier defendingSoldier)
        {
            defendingSoldier.TakeShieldDamage(attackingSoldier.Attack);
            defendingSoldier.TakeHealthDamage(attackingSoldier.Attack);
        }
    }
}
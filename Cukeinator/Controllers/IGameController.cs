using Cukeinator.Models;

namespace Cukeinator.Controllers
{
    public interface IGameController
    {
        void RunCombat(ICucumberSoldier playerSoldier, ISoldier computerSoldier);
    }
}
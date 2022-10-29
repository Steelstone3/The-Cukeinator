using Cukeinator.Models;

namespace Cukeinator.Controllers
{
    public interface IGameController
    {
        void PlayerTurn(ICucumberSoldier attackingSolider, ISoldier defendingSoldier);
        void ComputerTurn(ISoldier attackingSoldier, ICucumberSoldier defendingSoldier);
    }
}
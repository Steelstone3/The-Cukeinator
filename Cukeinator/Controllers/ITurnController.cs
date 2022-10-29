using Cukeinator.Models;

namespace Cukeinator.Controllers
{
    public interface ITurnController
    {
        void PlayerTurn(ICucumberSoldier attackingSolider, ISoldier defendingSoldier);
        void ComputerTurn(ISoldier attackingSoldier, ICucumberSoldier defendingSoldier);
    }
}
using Cukeinator.Models;

namespace Cukeinator.Controllers
{
    public interface ITurnController
    {
        bool PlayerTurn(ICucumberSoldier attackingSolider, ISoldier defendingSoldier);
        bool ComputerTurn(ISoldier attackingSoldier, ICucumberSoldier defendingSoldier);
    }
}
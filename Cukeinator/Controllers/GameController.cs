using Cukeinator.Models;
using Cukeinator.Presenters;

namespace Cukeinator.Controllers
{
    public class GameController : IGameController
    {
        private IPresenter presenter;
        private ITurnController turnController;

        public GameController(IPresenter presenter, ITurnController turnController)
        {
            this.presenter = presenter;
            this.turnController = turnController;
        }

        public void RunCombat(ICucumberSoldier playerSoldier, ISoldier computerSoldier)
        {
            turnController.PlayerTurn(playerSoldier, computerSoldier);
            presenter.Print($"Player soldier does {playerSoldier.Attack} to computer soldier.");
            turnController.ComputerTurn(computerSoldier, playerSoldier);
            presenter.Print($"Computer soldier does {computerSoldier.Attack} to player soldier.");

            presenter.Print($"| Player soldier | Shields: {playerSoldier.Shields} | Health: {playerSoldier.Health} |\n| Computer soldier | Health: {computerSoldier.Health} |");
        }
    }
}
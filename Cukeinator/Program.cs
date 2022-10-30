using Cukeinator.Controllers;
using Cukeinator.Models;
using Cukeinator.Presenters;

namespace BubblesDivePlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            IPresenter presenter = new Presenter();
            ITurnController turnController = new TurnController();
            IGameController gameController = new GameController(presenter, turnController);
            
            ICucumberSoldier playerSoldier = new CucumberSoldier();
            ISoldier computerSoldier = new FruitSoldier();

            gameController.RunCombat(playerSoldier, computerSoldier);
        }
    }
}

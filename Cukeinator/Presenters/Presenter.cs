using Spectre.Console;

namespace Cukeinator.Presenters
{
    public class Presenter : IPresenter
    {
        public void Print(string message)
        {
            AnsiConsole.Write(new Markup(message));
        }
    }
}

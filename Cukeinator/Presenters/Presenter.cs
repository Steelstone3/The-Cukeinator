using Spectre.Console;

namespace Cukeinator.Presenters
{
    public class Presenter : IPresenter
    {
        public void Print(string message)
        {
            message += "\n\n";
            AnsiConsole.Write(new Markup(message));
        }
    }
}

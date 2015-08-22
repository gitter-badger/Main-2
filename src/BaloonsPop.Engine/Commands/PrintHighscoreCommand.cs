namespace BaloonsPop.Engine.Commands
{
    using BaloonsPop.Common.Contracts;

    public class PrintHighscoreCommand : PrintCommands
    {
        private IHighscoreTable table;

        private IPrinter printer;

        public PrintHighscoreCommand(IPrinter printer, IHighscoreTable table) 
            : base(printer)
        {
            this.printer = printer;
            this.table = table;
        }

        public override void Execute()
        {
            this.printer.PrintHighscore(this.table);
        }
    }
}
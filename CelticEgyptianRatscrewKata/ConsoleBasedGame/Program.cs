using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class Program
    {
        static void Main()
        {
            var ratscrewGame = new RatscrewGame(new RatscrewGameFactory(), new ConsoleUserInterface());
            ratscrewGame.Play(new ConsoleLog());
        }
    }
}

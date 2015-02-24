using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class Program
    {
        static void Main()
        {
            var ratscrewGame = new RatscrewGame(new GameFactory(), new UserInterface());
            ratscrewGame.Play(new ConsoleLog());
        }
    }
}

using System.Collections.Generic;
using CelticEgyptianRatscrewKata;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new ConsoleLog();
            var userInterface = new UserInterface();

            var ratscrewGame = new RatscrewGame(log, userInterface);
            ratscrewGame.Play();
        }
    }
}

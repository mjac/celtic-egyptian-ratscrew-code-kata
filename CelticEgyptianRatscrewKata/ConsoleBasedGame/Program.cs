using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController game = new GameFactory().Create();

            var userInterface = new UserInterface();
            IEnumerable<PlayerInfo> playerInfos = userInterface.GetPlayerInfoFromUserLazily();

            foreach (PlayerInfo playerInfo in playerInfos)
            {
                game.AddPlayer(playerInfo);
            }

            game.StartGame(GameFactory.CreateFullDeckOfCards());

            char userInput;
            while (userInterface.TryReadUserInput(out userInput))
            {

            } 
        }
    }
}

using System.Collections.Generic;
using CelticEgyptianRatscrewKata;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class RatscrewGame
    {
        public void Play(ILog log, UserInterface userInterface)
        {
            var game = new GameFactory().Create(log);
            var actionManager = new ActionManager(game);

            IEnumerable<PlayerInfo> playerInfos = userInterface.GetPlayerInfoFromUserLazily();

            foreach (PlayerInfo playerInfo in playerInfos)
            {
                game.AddPlayer(playerInfo);
                actionManager.Bind(playerInfo);
            }

            game.StartGame(GameFactory.CreateFullDeckOfCards());

            char userInput;
            while (userInterface.TryReadUserInput(out userInput))
            {
                actionManager.Process(userInput);

                IPlayer winner;
                if (game.TryGetWinner(out winner))
                {
                    log.Log(string.Format("{0} won the game!", winner.Name));
                    break;
                }
            }
        }
    }
}
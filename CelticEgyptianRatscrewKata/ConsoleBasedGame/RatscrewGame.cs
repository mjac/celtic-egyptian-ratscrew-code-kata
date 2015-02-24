using System.Collections.Generic;
using CelticEgyptianRatscrewKata;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class RatscrewGame
    {
        private readonly ILog m_Log;
        private readonly UserInterface m_UserInterface;

        public RatscrewGame(ILog log, UserInterface userInterface)
        {
            m_Log = log;
            m_UserInterface = userInterface;
        }

        public void Play()
        {
            var game = new GameFactory().Create(m_Log);
            var actionManager = new ActionManager(game);

            IEnumerable<PlayerInfo> playerInfos = m_UserInterface.GetPlayerInfoFromUserLazily();

            foreach (PlayerInfo playerInfo in playerInfos)
            {
                game.AddPlayer(playerInfo);
                actionManager.Bind(playerInfo);
            }

            game.StartGame(GameFactory.CreateFullDeckOfCards());

            char userInput;
            while (m_UserInterface.TryReadUserInput(out userInput))
            {
                actionManager.Process(userInput);

                IPlayer winner;
                if (game.TryGetWinner(out winner))
                {
                    m_Log.Log(string.Format("{0} won the game!", winner.Name));
                    break;
                }
            }
        }
    }
}
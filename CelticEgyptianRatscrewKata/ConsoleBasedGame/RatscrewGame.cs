using System.Collections.Generic;
using CelticEgyptianRatscrewKata;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class RatscrewGame
    {
        private readonly ILog m_Log;
        private readonly IUserInterface m_UserInterface;

        public RatscrewGame(ILog log, IUserInterface userInterface)
        {
            m_Log = log;
            m_UserInterface = userInterface;
        }

        public void Play()
        {
            var game = new GameFactory().Create(m_Log);
            var actionManager = new ActionManager(game);

            SetUp(game, actionManager);
            StartGame(game, actionManager);
        }

        private void SetUp(IGameController game, ActionManager actionManager)
        {
            IEnumerable<PlayerInfo> playerInfos = m_UserInterface.GetPlayerInfoFromUser();

            foreach (PlayerInfo playerInfo in playerInfos)
            {
                game.AddPlayer(playerInfo);
                actionManager.Bind(playerInfo);
            }
        }

        private void StartGame(IGameController game, ActionManager actionManager)
        {
            game.StartGame(GameFactory.CreateFullDeckOfCards());

            char userInput;
            while (m_UserInterface.TryReadUserInput(out userInput))
            {
                actionManager.Process(userInput);

                IPlayer winner;
                if (game.TryGetWinner(out winner))
                {
                    break;
                }
            }
        }
    }
}
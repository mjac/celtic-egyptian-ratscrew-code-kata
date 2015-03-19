using System;
using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.CallingOut
{
    public class CallOutLoggedGameController : IGameController
    {
        private readonly ICalledRankProvider m_CalledRankProvider;
        private readonly IGameController m_GameController;
        private readonly ILog m_Log;

        public CallOutLoggedGameController(ICalledRankProvider calledRankProvider, IGameController gameController, ILog log)
        {
            m_GameController = gameController;
            m_Log = log;
            m_CalledRankProvider = calledRankProvider;
        }

        public bool AddPlayer(IPlayer player)
        {
            return m_GameController.AddPlayer(player);
        }

        public Card PlayCard(IPlayer player)
        {
            var playCard = m_GameController.PlayCard(player);
            m_Log.Log(String.Format("Player {0} called out rank {1}", player.Name, m_CalledRankProvider.GetCurrentRank()));

            return playCard;
        }

        public bool AttemptSnap(IPlayer player)
        {
            return m_GameController.AttemptSnap(player);
        }

        public void StartGame(Cards deck)
        {
            m_GameController.StartGame(deck);
        }

        public bool TryGetWinner(out IPlayer winner)
        {
            return m_GameController.TryGetWinner(out winner);
        }

        public IEnumerable<IPlayer> Players
        {
            get { return m_GameController.Players; }
        }

        public int StackSize
        {
            get { return m_GameController.StackSize; }
        }

        public Card TopOfStack
        {
            get { return m_GameController.TopOfStack; }
        }

        public int NumberOfCards(IPlayer player)
        {
            return m_GameController.NumberOfCards(player);
        }
    }
}
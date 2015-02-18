using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.GameSetup;
using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Game
{
    /// <summary>
    /// Controls a game of Celtic Egyptian Ratscrew.
    /// </summary>
    public class GameController : IGameController
    {
        private readonly ISnapValidator _snapValidator;
        private readonly IDealer _dealer;
        private readonly IShuffler _shuffler;
        private readonly IList<IPlayer> _players;
        private readonly IGameState _gameState;
        private readonly ILog _log;

        public GameController(IGameState gameState, ISnapValidator snapValidator, IDealer dealer, IShuffler shuffler, ILog log)
        {
            _players = new List<IPlayer>();
            _gameState = gameState;
            _snapValidator = snapValidator;
            _dealer = dealer;
            _shuffler = shuffler;
            _log = log;
        }

        public bool AddPlayer(IPlayer player)
        {
            if (_players.Any(x => x.Name == player.Name)) return false;

            _players.Add(player);
            _gameState.AddPlayer(player.Name, Cards.Empty());
            return true;
        }

        public void PlayCard(IPlayer player)
        {
            if (_gameState.HasCards(player.Name))
            {
                var playedCard = _gameState.PlayCard(player.Name);
                _log.Log(string.Format("{0} has played the {1}", player.Name, playedCard));
            }
            LogGameState();
        }

        private void LogGameState()
        {
            _log.Log(string.Format("Stack ({0}): {1} ", _gameState.Stack.Count(), _gameState.Stack.Any() ? _gameState.Stack.First().ToString() : ""));
            foreach (var player in _players)
            {
                _log.Log(string.Format("{0}: {1} cards", player.Name, _gameState.NumberOfCards(player.Name)));
            }
        }

        public void AttemptSnap(IPlayer player)
        {
            AddPlayer(player);

            if (_snapValidator.CanSnap(_gameState.Stack))
            {
                _gameState.WinStack(player.Name);
                _log.Log(string.Format("{0} won the stack", player.Name));
            }
            else
            {
                _log.Log(string.Format("{0} did not win the stack", player.Name));
            }
            LogGameState();
        }

        /// <summary>
        /// Starts a game with the currently added players
        /// </summary>
        public void StartGame(Cards deck)
        {
            _gameState.Clear();

            var shuffledDeck = _shuffler.Shuffle(deck);
            var decks = _dealer.Deal(_players.Count, shuffledDeck);
            for (var i = 0; i < decks.Count; i++)
            {
                _gameState.AddPlayer(_players[i].Name, decks[i]);
            }
            LogGameState();
        }

        public bool TryGetWinner(out IPlayer winner)
        {
            var playersWithCards = _players.Where(p => _gameState.HasCards(p.Name)).ToList();
            {
                winner = playersWithCards.Single();
                return true;
            }

            winner = null;
            return false;
        }
    }
}

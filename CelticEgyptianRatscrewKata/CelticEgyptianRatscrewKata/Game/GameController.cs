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
                _gameState.PlayCard(player.Name);
            }
        }

        public void AttemptSnap(IPlayer player)
        {
            AddPlayer(player);

            if (_snapValidator.CanSnap(_gameState.Stack))
            {
                _gameState.WinStack(player.Name);
            }
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

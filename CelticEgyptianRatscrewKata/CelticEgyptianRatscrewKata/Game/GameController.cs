using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private int _expectedPlayerIndex;

        public GameController(IGameState gameState, ISnapValidator snapValidator, IDealer dealer, IShuffler shuffler)
        {
            _players = new List<IPlayer>();
            _gameState = gameState;
            _snapValidator = snapValidator;
            _dealer = dealer;
            _shuffler = shuffler;
        }

        public IEnumerable<IPlayer> Players
        {
            get { return _players; }
        }

        public int StackSize
        {
            get { return _gameState.Stack.Count(); }
        }

        public Card TopOfStack
        {
            get { return _gameState.Stack.FirstOrDefault(); }
        }

        public int NumberOfCards(IPlayer player)
        {
            return _gameState.NumberOfCards(player.Name);
        }

        public bool AddPlayer(IPlayer player)
        {
            if (Players.Any(x => x.Name == player.Name)) return false;

            _players.Add(player);
            _gameState.AddPlayer(player.Name, Cards.Empty());
            return true;
        }

        public Card TakeTurn(IPlayer player)
        {
            var playerIndex = _players.IndexOf(player);

            if (playerIndex != _expectedPlayerIndex)
            {
                _gameState.FaultCard(player.Name);
                AddPenalty(player);
                return null;
            }

            var card = PlayCard(player);
            UpdateNextExpectedPlayer(playerIndex);

            return card;
        }

        private Card PlayCard(IPlayer player)
        {
            if (_gameState.HasCards(player.Name))
            {
                return _gameState.PlayCard(player.Name);
            }

            return null;
        }

        public bool AttemptSnap(IPlayer player)
        {
            AddPlayer(player);

            if (player.HasPenalty)
            {
                return false;
            }

            if (_snapValidator.CanSnap(_gameState.Stack))
            {
                _gameState.WinStack(player.Name);
                return true;
            }

            AddPenalty(player);

            return false;
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

            _expectedPlayerIndex = 0;
        }

        public bool TryGetWinner(out IPlayer winner)
        {
            var playersWithCards = _players.Where(p => _gameState.HasCards(p.Name)).ToList();

            if (!_gameState.Stack.Any() && playersWithCards.Count() == 1)
            {
                winner = playersWithCards.Single();
                return true;
            }

            winner = null;
            return false;
        }

        private void UpdateNextExpectedPlayer(int playerIndex)
        {
            _expectedPlayerIndex = (playerIndex + 1) % _players.Count;
        }

        private void AddPenalty(IPlayer player)
        {
            player.HasPenalty = true;

            if (_players.All(p => p.HasPenalty))
            {
                foreach (IPlayer p in _players)
                {
                    p.HasPenalty = false;
                }
            }
        }
    }
}

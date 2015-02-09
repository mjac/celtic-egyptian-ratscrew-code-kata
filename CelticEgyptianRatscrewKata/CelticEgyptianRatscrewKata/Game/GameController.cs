using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Game
{
    /// <summary>
    /// Controls a game of Celtic Egyptian Ratscrew.
    /// </summary>
    public class GameController
    {
        private readonly SnapValidator _snapValidator;
        private readonly Dealer _dealer;
        private readonly Shuffler _shuffler;
        private readonly IList<IPlayer> _players;
        private GameState _gameState;

        public GameController(SnapValidator snapValidator, Dealer dealer, Shuffler shuffler)
        {
            _players = new List<IPlayer>();
            _gameState = new GameState();
            _snapValidator = snapValidator;
            _dealer = dealer;
            _shuffler = shuffler;
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

            if (_snapValidator.IsSnapValid(_gameState.Stack))
            {
                _gameState.WinStack(player.Name);
            }
        }

        /// <summary>
        /// Starts a game with the currently added players
        /// </summary>
        public void StartGame(Cards deck)
        {
            _gameState = new GameState();

            var shuffledDeck = _shuffler.Shuffle(deck);
            var decks = _dealer.Deal(_players.Count, shuffledDeck);
            for (var i = 0; i < decks.Count; i++)
            {
                _gameState.AddPlayer(_players[i].Name, decks[i]);
            }
        }
    }
}
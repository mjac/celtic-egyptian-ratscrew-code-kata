using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Game
{
    /// <summary>
    /// Represents the state of the game at any point.
    /// </summary>
    public class GameState
    {
        private readonly Cards _stack;
        private readonly IDictionary<string, Cards> _decks;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameState(IDictionary<string, Cards> decks)
            : this(Cards.Empty(), decks) {}

        /// <summary>
        /// Constructor to allow setting the central stack.
        /// </summary>
        public GameState(Cards stack, IDictionary<string, Cards> decks)
        {
            _stack = stack;
            _decks = decks;
        }

        /// <summary>
        /// Play the top card of the given player's deck.
        /// </summary>
        public void PlayCard(string playerId)
        {
            Debug.Assert(_decks.ContainsKey(playerId));
            Debug.Assert(_decks[playerId].Any());

            var topCard = _decks[playerId].Pop();
            _stack.AddToTop(topCard);
        }
    }
}
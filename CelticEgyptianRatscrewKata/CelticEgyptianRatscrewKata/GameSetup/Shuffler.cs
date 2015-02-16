using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.GameSetup
{
    public class Shuffler : IShuffler
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public Shuffler() : this(new RandomNumberGenerator())
        {
        }

        public Shuffler(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public Cards Shuffle(Cards deck)
        {
            var shuffledDeck = new List<Card>();

            var unshuffledDeck = Cards.With(deck.ToArray());
            while (unshuffledDeck.HasCards)
            {
                var randomInt = _randomNumberGenerator.Get(0, unshuffledDeck.Count());
                var nextCard = unshuffledDeck.CardAt(randomInt);
                unshuffledDeck.RemoveCardAt(randomInt);
                shuffledDeck.Add(nextCard);
            }

            return Cards.With(shuffledDeck.ToArray());
        }
    }
}
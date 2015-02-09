using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class Stack : IEnumerable<Card>
    {
        private readonly List<Card> _cards;

        public Stack(IEnumerable<Card> cards)
        {
            _cards = new List<Card>(cards);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Stack Empty()
        {
            return new Stack(Enumerable.Empty<Card>());
        }
    }
}
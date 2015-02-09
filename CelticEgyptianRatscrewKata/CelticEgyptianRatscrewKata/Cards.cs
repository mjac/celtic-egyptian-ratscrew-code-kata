using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class Cards : IEnumerable<Card>
    {
        private readonly List<Card> _cards;

        public Cards(IEnumerable<Card> cards)
        {
            _cards = new List<Card>(cards);
        }

        public void AddToTop(Card card)
        {
            _cards.Insert(0, card);
        }

        public void AddToBottom(Card card)
        {
            _cards.Insert(_cards.Count, card);
        }

        public Card Pop()
        {
            var first = _cards.First();
            _cards.RemoveAt(0);
            return first;
        }

        public Card CardAt(int i)
        {
            return _cards.ElementAt(i);
        }

        public void RemoveCardAt(int i)
        {
            _cards.RemoveAt(i);
        }

        public bool HasCards
        {
            get { return _cards.Count > 0; } 
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Cards Empty()
        {
            return With();
        }

        public static Cards With(Cards cards)
        {
            return With(cards.ToArray());
        }

        public static Cards With(params Card[] cards)
        {
            return new Cards(cards);
        }

        public override string ToString()
        {
            var output = "";

            foreach (var card in _cards)
            {
                if (!output.Equals("")) output += ", ";
                output += card;
            }

            return output;
        }
    }
}
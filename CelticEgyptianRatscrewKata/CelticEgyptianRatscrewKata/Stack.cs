using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class Stack : IEnumerable<Card>
    {
        private readonly Stack<Card> m_Cards;

        public Stack()
        {
            m_Cards = new Stack<Card>();
        }

        /// <summary>
        /// Create a stack with these cards, with the first at the top
        /// </summary>
        public Stack(IEnumerable<Card> cards)
        {
            m_Cards = new Stack<Card>(cards.Reverse());
        }

        public void PlaceCardOnTop(Card card)
        {
            m_Cards.Push(card);
        }

        public bool TryPeekTopCard(out Card card)
        {
            if (m_Cards.Any())
            {
                card = m_Cards.Peek();
                return true;
            }

            card = null;
            return false;
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return m_Cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
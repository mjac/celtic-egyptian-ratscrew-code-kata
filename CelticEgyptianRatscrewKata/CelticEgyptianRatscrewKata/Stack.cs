using System.Collections;
using System.Collections.Generic;

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
        /// Create a stack with these cards, with the first at the bottom
        /// </summary>
        public Stack(IEnumerable<Card> cards)
        {
            m_Cards = new Stack<Card>(cards);
        }

        public void PlaceCardOnTop(Card card)
        {
            m_Cards.Push(card);
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
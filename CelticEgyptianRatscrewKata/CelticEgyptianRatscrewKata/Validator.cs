using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    class Validator
    {
        public virtual bool Validate(Stack stack)
        {
            return false;
        }
    }

    class DarkQueenValidator : Validator
    {
        public override bool Validate(Stack stack)
        {
            Card topCard;
            if (stack.TryPeekTopCard(out topCard))
            {
                if (Equals(topCard, new Card(Suit.Spades, Rank.Queen))) 
                    return true;
            }

            return false;
        }
    }

    class StandardValidator : Validator
    {
        public override bool Validate(Stack stack)
        {
            Card lastCard = null;

            foreach (Card card in stack)
            {
                if (lastCard != null && lastCard.HasSameRank(card))
                {
                    return true;
                }

                lastCard = card;
            }

            return false;
        }
    }

    class SandwichValidator : Validator
    {
        public override bool Validate(Stack stack)
        {
            Card twoCardsAgo = null;
            Card lastCard = null;

            foreach (Card card in stack)
            {
                if (twoCardsAgo != null && lastCard != null && twoCardsAgo.HasSameRank(card))
                {
                    return true;
                }
                
                twoCardsAgo = lastCard;
                lastCard = card;
            }

            return false;
        }
    }
}

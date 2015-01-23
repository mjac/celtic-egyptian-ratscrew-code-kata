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
}

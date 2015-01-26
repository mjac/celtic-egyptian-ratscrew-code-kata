namespace CelticEgyptianRatscrewKata
{
    class DarkQueenValidator : ISnapValidator
    {
        public bool Validate(Stack stack)
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
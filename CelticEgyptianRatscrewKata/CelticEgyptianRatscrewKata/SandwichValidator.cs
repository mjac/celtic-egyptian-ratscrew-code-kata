namespace CelticEgyptianRatscrewKata
{
    class SandwichValidator : ISnapValidator
    {
        public bool Validate(Stack stack)
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
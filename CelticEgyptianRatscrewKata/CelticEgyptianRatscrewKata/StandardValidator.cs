namespace CelticEgyptianRatscrewKata
{
    class StandardValidator : ISnapValidator
    {
        public bool Validate(Stack stack)
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
}
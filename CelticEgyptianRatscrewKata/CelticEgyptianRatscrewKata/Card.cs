namespace CelticEgyptianRatscrewKata
{
    public class Card
    {
        private readonly Suit _suit;
        private readonly Rank _rank;

        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }

        public override string ToString()
        {
            return string.Format("Card {0} of {1}", _rank, _suit);
        }

        #region EqualityMembers
        protected bool Equals(Card other)
        {
            return _suit == other._suit && _rank == other._rank;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) _suit*397) ^ (int) _rank;
            }
        }
#endregion
    }
}
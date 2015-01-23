using System.Linq;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    /// <summary>
    /// Represents a standard snap, i.e. any two adjacent cards have the same rank.
    /// </summary>
    public class StandardSnapRule : ISnapRule
    {
        public bool IsSnapValid(Stack cardStack)
        {
            Rank? previous = null;
            foreach (var card in cardStack)
            {
                if (card.Rank == previous)
                {
                    return true;
                }
                previous = card.Rank;
            }
            return false;
        }
    }
}
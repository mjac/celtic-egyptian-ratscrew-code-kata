using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata
{
    /// <summary>
    /// Represents the rule where the queen of spades is on the top.
    /// </summary>
    public class DarkQueenRule : ISnapRule
    {
        public bool IsSnapValid(Stack cardStack)
        {
            return false;
        }
    }
}
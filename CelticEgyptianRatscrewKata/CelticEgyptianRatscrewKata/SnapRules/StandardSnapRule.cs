namespace CelticEgyptianRatscrewKata.SnapRules
{
    /// <summary>
    /// Represents a standard snap, i.e. any two adjacent cards have the same rank.
    /// </summary>
    public class StandardSnapRule : ISnapRule
    {
        public bool IsSnapValid(Stack cardStack)
        {
            return false;
        }
    }
}
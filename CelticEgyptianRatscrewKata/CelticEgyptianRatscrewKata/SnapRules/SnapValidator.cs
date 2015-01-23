namespace CelticEgyptianRatscrewKata.SnapRules
{
    /// <summary>
    /// Aggregates snap rules to see if any are true.
    /// </summary>
    public class SnapValidator
    {
        private readonly ISnapRule[] _rules;

        /// <summary>
        /// Create snap validator that will check against all the given <paramref name="rules"/>
        /// </summary>
        public SnapValidator(params ISnapRule[] rules)
        {
            _rules = rules;
        }

        /// <summary>
        /// Checks if <paramref name="cardStack"/> has any valid snaps.
        /// </summary>
        public bool IsSnapValid(Stack cardStack)
        {
            return false;
        }
    }
}
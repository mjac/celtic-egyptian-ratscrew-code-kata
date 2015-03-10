using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    /// <summary>
    /// Aggregates snap rules to see if any are true.
    /// </summary>
    public class SnapValidator : ISnapValidator
    {
        private readonly IEnumerable<ICardSnapRule> _rules;

        /// <summary>
        /// Create snap validator that will check against all the given <paramref name="rules"/>
        /// </summary>
        public SnapValidator(params ICardSnapRule[] rules)
        {
            _rules = rules;
        }

        /// <summary>
        /// Checks if <paramref name="cardStack"/> has any valid snaps.
        /// </summary>
        public bool CanSnap(Cards cardStack)
        {
            return _rules.Any(r => r.IsSnapValid(cardStack));
        }
    }
}
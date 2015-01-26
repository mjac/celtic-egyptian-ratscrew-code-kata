using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    class CompositeValidator : ISnapValidator
    {
        private readonly List<ISnapValidator> _validators = new List<ISnapValidator>();

        public void AddValidator(ISnapValidator validator)
        {
            _validators.Add(validator);
        }

        public bool Validate(Stack stack)
        {
            return _validators.Any(validator => validator.Validate(stack));
        }
    }
}
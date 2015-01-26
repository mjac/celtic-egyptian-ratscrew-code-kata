using System.Runtime.InteropServices;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata
{
    class SnapValidator : ISnapValidator
    {
        public bool Validate(Stack stack)
        {
            var darkQueenValidator = new DarkQueenValidator();
            var standardValidator = new StandardValidator();
            var sandwichValidator = new SandwichValidator();

            if (darkQueenValidator.Validate(stack))
                return true;
            if (standardValidator.Validate(stack))
                return true;
            if (sandwichValidator.Validate(stack))
                return true;

            return false;
        }
    }
}

using System.Runtime.InteropServices;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata
{
    class SnapValidatorFactory
    {
        public ISnapValidator CreateSnapValidator()
        {
            var compositeValidator = new CompositeValidator();

            compositeValidator.AddValidator(new DarkQueenValidator());
            compositeValidator.AddValidator(new StandardValidator());
            compositeValidator.AddValidator(new SandwichValidator());

            return compositeValidator;
        }
    }
}

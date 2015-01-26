using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class CompositeValidatorTests
    {
        private static readonly ISnapValidator AlwaysTrueSnapValidator = new DummySnapValidator(true);
        private static readonly ISnapValidator AlwaysFalseSnapValidator = new DummySnapValidator(false);
        private static readonly Stack EmptyCardStack = new Stack();

        [Test]
        public void ReturnFalseIfNoValidators()
        {
            // Arrange
            var validator = new CompositeValidator();
 
            // Act
            var hasSnap = validator.Validate(EmptyCardStack);

            // Assert
            Assert.False(hasSnap);
        }

        [Test]
        public void ReturnTrueIfSingleAlwaysTrueValidator()
        {
            // Arrange
            var validator = new CompositeValidator();
            validator.AddValidator(AlwaysTrueSnapValidator);

            // Act
            var hasSnap = validator.Validate(EmptyCardStack);

            // Assert
            Assert.True(hasSnap);
        }

        [Test]
        public void ReturnFalseIfSingleAlwaysFalseValidator()
        {
            // Arrange
            var validator = new CompositeValidator();
            validator.AddValidator(AlwaysFalseSnapValidator);

            // Act
            var hasSnap = validator.Validate(EmptyCardStack);

            // Assert
            Assert.False(hasSnap);
        }

        [Test]
        public void ReturnTrueIfTrueAndFalseValidators()
        {
            // Arrange
            var validator = new CompositeValidator();
            validator.AddValidator(AlwaysTrueSnapValidator);
            validator.AddValidator(AlwaysFalseSnapValidator);

            // Act
            var hasSnap = validator.Validate(EmptyCardStack);

            // Assert
            Assert.True(hasSnap);
        }
    }
}

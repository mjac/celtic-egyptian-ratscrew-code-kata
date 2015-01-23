using System.Collections.Generic;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class ValidatorTests
    {
        [Test]
        public void DetectDarkQueenOnTop()
        {
            // Arrange
            var expectedcard = new Card(Suit.Spades, Rank.Queen);

            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(expectedcard);

            var validator = new Validator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.True(hasSnap);
        }
    }
}

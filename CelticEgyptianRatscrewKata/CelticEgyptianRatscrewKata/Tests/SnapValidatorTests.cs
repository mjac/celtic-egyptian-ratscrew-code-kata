using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class SnapValidatorTests
    {
        private static readonly Card DarkQueenCard = new Card(Suit.Spades, Rank.Queen);

        [Test]
        public void DetectDarkQueen()
        {
            // Arrange
            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(DarkQueenCard);

            var validator = new SnapValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.True(hasSnap);
        }
    }
}

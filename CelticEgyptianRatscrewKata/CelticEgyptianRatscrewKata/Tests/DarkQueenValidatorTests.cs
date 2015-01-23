using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class DarkQueenValidatorTests
    {
        private static readonly Card DarkQueenCard = new Card(Suit.Spades, Rank.Queen);

        [Test]
        public void DetectDarkQueenOnTop()
        {
            // Arrange
            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(DarkQueenCard);

            var validator = new DarkQueenValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.True(hasSnap);
        }

        [Test]
        public void OtherCardsNotDetectedOnTop()
        {
            // Arrange
            var expectedcard = new Card(Suit.Hearts, Rank.Four);
            Assert.AreNotEqual(DarkQueenCard, expectedcard);

            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(expectedcard);

            var validator = new DarkQueenValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.False(hasSnap);
        }

        [Test]
        public void DarkQueenNotDetectedUnderTop()
        {
            // Arrange
            var othercard = new Card(Suit.Hearts, Rank.Four);
            Assert.AreNotEqual(DarkQueenCard, othercard);

            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(DarkQueenCard);
            cardstack.PlaceCardOnTop(othercard);

            var validator = new DarkQueenValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.False(hasSnap);
        }
    }
}

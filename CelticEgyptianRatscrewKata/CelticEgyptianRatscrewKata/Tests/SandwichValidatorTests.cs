using NUnit.Framework;
namespace CelticEgyptianRatscrewKata.Tests
{
    public class SandwichValidatorTests
    {
        private static readonly Card FourOfHearts = new Card(Suit.Hearts, Rank.Four);
        private static readonly Card FourOfClubs = new Card(Suit.Clubs, Rank.Four);
        private static readonly Card KingOfSpades = new Card(Suit.Spades, Rank.King);

        [Test]
        public void DoNotDetectOnEmptyStack()
        {
            // Arrange
            var cardstack = new Stack();

            var validator = new SandwichValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.False(hasSnap);
        }

        [Test]
        public void DoNotDetectOnSingleCardStack()
        {
            // Arrange
            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(FourOfHearts);

            var validator = new SandwichValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.False(hasSnap);
        }

        [Test]
        public void DoNotDetectSameRankOnTwoCardStack()
        {
            // Arrange
            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(FourOfHearts);
            cardstack.PlaceCardOnTop(FourOfClubs);

            var validator = new SandwichValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.False(hasSnap);
        }

        [Test]
        public void DetectSameRankWithGapOnThreeCardStack()
        {
            // Arrange
            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(FourOfHearts);
            cardstack.PlaceCardOnTop(KingOfSpades);
            cardstack.PlaceCardOnTop(FourOfClubs);

            var validator = new SandwichValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.True(hasSnap);
        }
    }
}

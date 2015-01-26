using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class StandardValidatorTests
    {
        private static readonly Card FourOfHearts = new Card(Suit.Hearts, Rank.Four);
        private static readonly Card FourOfClubs = new Card(Suit.Clubs, Rank.Four);
        private static readonly Card KingOfSpades = new Card(Suit.Spades, Rank.King);

        [Test]
        public void DoNotDetectOnEmptyStack()
        {
            // Arrange
            var cardstack = new Stack();

            var validator = new StandardValidator();

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

            var validator = new StandardValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.False(hasSnap);
        }

        [Test]
        public void DetectSameTwoCardsInTwoCardStack()
        {
            // Arrange
            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(FourOfHearts);
            cardstack.PlaceCardOnTop(FourOfHearts);

            var validator = new StandardValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.True(hasSnap);
        }

        [Test]
        public void DetectTwoCardsOfSameRankInTwoCardStack()
        {
            // Arrange
            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(FourOfHearts);
            cardstack.PlaceCardOnTop(FourOfClubs);

            var validator = new StandardValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.True(hasSnap);
        }

        [Test]
        public void DetectTwoCardsOfSameRankAtBottomOfThreeCardStack()
        {
            // Arrange
            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(KingOfSpades);
            cardstack.PlaceCardOnTop(FourOfHearts);
            cardstack.PlaceCardOnTop(FourOfClubs);

            var validator = new StandardValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.True(hasSnap);
        }

        [Test]
        public void DetectTwoCardsOfSameRankAtTopOfThreeCardStack()
        {
            // Arrange
            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(FourOfHearts);
            cardstack.PlaceCardOnTop(FourOfClubs);
            cardstack.PlaceCardOnTop(KingOfSpades);

            var validator = new StandardValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.True(hasSnap);
        }

        [Test]
        public void DoNotDetectTwoCardsOfSameRankWithSingleCardGap()
        {
            // Arrange
            var cardstack = new Stack();
            cardstack.PlaceCardOnTop(FourOfHearts);
            cardstack.PlaceCardOnTop(KingOfSpades);
            cardstack.PlaceCardOnTop(FourOfClubs);

            var validator = new StandardValidator();

            // Act
            var hasSnap = validator.Validate(cardstack);

            // Assert
            Assert.False(hasSnap);
        }
    }
}

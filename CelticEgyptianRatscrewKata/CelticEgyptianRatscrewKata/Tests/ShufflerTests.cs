using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class ShufflerTests
    {
        [Test]
        public void ShufflingEmptyDeckReturnsEmptyDeck()
        {
            var deck = Cards.Empty();
            var shuffler = new Shuffler();

            var shuffledDeck = shuffler.Shuffle(deck);

            var expectedDeck = Cards.Empty();
            Assert.That(shuffledDeck, Is.EqualTo(expectedDeck));
        }

        [Test]
        public void ShufflingDeckWithOneCardReturnsDeckWithOneCard()
        {
            var deck = Cards.With(AceOfClubs());
            var shuffler = new Shuffler();

            var shuffledDeck = shuffler.Shuffle(deck);

            var expectedDeck = Cards.With(AceOfClubs());
            Assert.That(shuffledDeck, Is.EqualTo(expectedDeck));
        }

        [Test]
        public void ShufflingDeckWithThreeCardsReturnsDeckWithTheCardsInADifferentOrder()
        {
            var deck = Cards.With(AceOfClubs(), TwoOfClubs(), ThreeOfClubs());
            var randomNumberGeneratorMock = Substitute.For<IRandomNumberGenerator>();
            randomNumberGeneratorMock.Get(0,3).Returns(1);
            randomNumberGeneratorMock.Get(0, 2).Returns(1);
            randomNumberGeneratorMock.Get(0, 1).Returns(0);
            var shuffler = new Shuffler(randomNumberGeneratorMock);

            var shuffledDeck = shuffler.Shuffle(deck);

            var expectedDeck = Cards.With(TwoOfClubs(), ThreeOfClubs(), AceOfClubs());
            Assert.That(shuffledDeck, Is.EqualTo(expectedDeck));
        }

        private static Card AceOfClubs()
        {
            return new Card(Suit.Clubs, Rank.Ace);
        }

        private static Card TwoOfClubs()
        {
            return new Card(Suit.Clubs, Rank.Two);
        }

        private static Card ThreeOfClubs()
        {
            return new Card(Suit.Clubs, Rank.Three);
        }
    }
}
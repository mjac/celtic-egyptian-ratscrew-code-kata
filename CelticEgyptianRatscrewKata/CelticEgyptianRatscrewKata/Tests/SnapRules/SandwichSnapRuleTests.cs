using CelticEgyptianRatscrewKata.SnapRules;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests.SnapRules
{
    [TestFixture]
    public class SandwichSnapRuleTests
    {
        [Test]
        public void ReturnsFalseOnEmptyStack()
        {
            //ARRANGE
            var sandwichSnapRule = new SandwichCardSnapRule();

            //ACT
            var result = sandwichSnapRule.IsSnapValid(Cards.Empty());

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueForABasicSandwichWith3Cards()
        {
            //ARRANGE
            var sandwichSnapRule = new SandwichCardSnapRule();
            var cardStack = new Cards(new []
            {
                new Card(Suit.Clubs, Rank.Ace), 
                new Card(Suit.Clubs, Rank.Two), 
                new Card(Suit.Diamonds, Rank.Ace), 
            });

            //ACT
            var result = sandwichSnapRule.IsSnapValid(cardStack);

            //ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnsTrueForABasicSandwichWith3CardsOfSameRank()
        {
            //ARRANGE
            var sandwichSnapRule = new SandwichCardSnapRule();
            var cardStack = new Cards(new []
            {
                new Card(Suit.Clubs, Rank.Ace), 
                new Card(Suit.Spades, Rank.Ace), 
                new Card(Suit.Diamonds, Rank.Ace), 
            });

            //ACT
            var result = sandwichSnapRule.IsSnapValid(cardStack);

            //ASSERT
            Assert.IsTrue(result);
        }
    }
}

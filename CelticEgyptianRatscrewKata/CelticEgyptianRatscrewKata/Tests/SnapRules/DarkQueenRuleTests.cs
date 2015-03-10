using CelticEgyptianRatscrewKata.SnapRules;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests.SnapRules
{
    [TestFixture]
    public class DarkQueenRuleTests
    {
        [Test]
        public void ReturnsFalseOnEmptyStack()
        {
            //ARRANGE
            var sandwichSnapRule = new DarkQueenCardSnapRule();

            //ACT
            var result = sandwichSnapRule.IsSnapValid(Cards.Empty());

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueWhenOnlyDarkQueenInStack()
        {
            //ARRANGE
            var sandwichSnapRule = new DarkQueenCardSnapRule();
            var stack = new Cards(new[]
            {
                new Card(Suit.Spades, Rank.Queen)
            });

            //ACT
            var result = sandwichSnapRule.IsSnapValid(stack);

            //ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnsTrueWhenDarkQueenTopOfStack()
        {
            //ARRANGE
            var sandwichSnapRule = new DarkQueenCardSnapRule();
            var stack = new Cards(new[]
            {
                new Card(Suit.Spades, Rank.Queen),
                new Card(Suit.Spades, Rank.Ace)
            });

            //ACT
            var result = sandwichSnapRule.IsSnapValid(stack);

            //ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnsFalseWhenDarkQueenNotTopOfStack()
        {
            //ARRANGE
            var sandwichSnapRule = new DarkQueenCardSnapRule();
            var stack = new Cards(new[]
            {
                new Card(Suit.Spades, Rank.Ace),
                new Card(Suit.Spades, Rank.Queen)
            });

            //ACT
            var result = sandwichSnapRule.IsSnapValid(stack);

            //ASSERT
            Assert.IsFalse(result);
        }
    }
}

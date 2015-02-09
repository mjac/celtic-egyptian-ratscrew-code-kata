using CelticEgyptianRatscrewKata.SnapRules;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public class SnapValidatorTests
    {
        [Test]
        public void ReturnsFalseIfNoRulesAndNoStack()
        {
            //ARRANGE
            var snapValidator = new SnapValidator();

            //ACT
            var result = snapValidator.IsSnapValid(Cards.Empty());

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueIfThereIsOneRuleAndItReturnsTrue()
        {
            //ARRANGE
            var alwaysTrueRule = Substitute.For<ISnapRule>();
            alwaysTrueRule.IsSnapValid(Arg.Any<Cards>()).Returns(true);
            var snapValidator = new SnapValidator(alwaysTrueRule);

            //ACT
            var result = snapValidator.IsSnapValid(Cards.Empty());

            //ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnsTrueOnlyOnSpecificStack()
        {
            //ARRANGE
            var cardStack = new Cards(new []
            {
                new Card(Suit.Clubs, Rank.Ace) 
            });

            var alwaysTrueRule = Substitute.For<ISnapRule>();
            alwaysTrueRule.IsSnapValid(Arg.Any<Cards>()).Returns(false);
            alwaysTrueRule.IsSnapValid(cardStack).Returns(true);

            var snapValidator = new SnapValidator(alwaysTrueRule);

            //ACT
            var result = snapValidator.IsSnapValid(cardStack);

            //ASSERT
            Assert.IsTrue(result);
        }
    }
}

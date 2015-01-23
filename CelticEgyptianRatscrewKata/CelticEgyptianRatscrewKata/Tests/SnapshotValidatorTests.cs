using CelticEgyptianRatscrewKata.SnapRules;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public class SnapshotValidatorTests
    {
        [Test]
        public void ReturnsFalseIfNoRulesAndNoStack()
        {
            //ARRANGE
            var snapValidator = new SnapValidator();

            //ACT
            var result = snapValidator.IsSnapValid(Stack.Empty());

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueIfThereIsOneRuleAndItReturnsTrue()
        {
            //ARRANGE
            var alwaysTrueRule = Substitute.For<ISnapRule>();
            alwaysTrueRule.IsSnapValid(Arg.Any<Stack>()).Returns(true);
            var snapValidator = new SnapValidator(alwaysTrueRule);

            //ACT
            var result = snapValidator.IsSnapValid(Stack.Empty());

            //ASSERT
            Assert.IsTrue(result);
        }
    }
}

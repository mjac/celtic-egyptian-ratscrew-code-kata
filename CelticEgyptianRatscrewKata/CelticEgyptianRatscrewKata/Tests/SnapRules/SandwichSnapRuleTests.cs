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
            var sandwichSnapRule = new SandwichSnapRule();

            //ACT
            var result = sandwichSnapRule.IsSnapValid(Stack.Empty());

            //ASSERT
            Assert.IsFalse(result);
        }
    }
}

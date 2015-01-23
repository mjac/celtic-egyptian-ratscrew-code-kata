using System.Linq;
using CelticEgyptianRatscrewKata.SnapRules;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests.SnapRules
{
    [TestFixture]
    public class StandardSnapRuleTests
    {
        private StandardSnapRule _standardSnapRule;

        [SetUp]
        public void SetUp()
        {
            _standardSnapRule = new StandardSnapRule();
        }

        [Test]
        public void ReturnsFalseIfEmpty()
        {
            //ARRANGE
            var stack = new Stack(Enumerable.Empty<Card>());

            //ACT
            var result = _standardSnapRule.IsSnapValid(stack);

            //ASSERT
            Assert.IsFalse(result);
        } 
    }
}

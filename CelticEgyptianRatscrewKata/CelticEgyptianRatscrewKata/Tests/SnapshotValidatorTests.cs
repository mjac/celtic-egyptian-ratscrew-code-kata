using System.Linq;
using CelticEgyptianRatscrewKata.SnapRules;
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
    }
}

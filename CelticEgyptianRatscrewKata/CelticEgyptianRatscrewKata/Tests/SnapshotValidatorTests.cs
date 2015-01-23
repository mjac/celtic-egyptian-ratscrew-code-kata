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
            var emptyStack = new Stack(Enumerable.Empty<Card>());

            //ACT
            var result = snapValidator.IsSnapValid(emptyStack);

            //ASSERT
            Assert.IsFalse(result);
        }
    }
}

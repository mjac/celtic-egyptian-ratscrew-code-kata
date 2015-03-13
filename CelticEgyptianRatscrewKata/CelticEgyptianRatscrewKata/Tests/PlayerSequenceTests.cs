using CelticEgyptianRatscrewKata.Game;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class PlayerSequenceTests
    {
        [Test]
        public void GivenEmptyPlayerSequence_AdvanceToNextPlayer_ShouldNotThrow()
        {
            var playerSequence = new PlayerSequence();
            Assert.DoesNotThrow(() => playerSequence.AdvanceToNextPlayer());
        }

    }
}

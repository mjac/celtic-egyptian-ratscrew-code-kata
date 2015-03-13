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

        [Test]
        public void GivenEmptyPlayerSequence_IsCurrentPlayer_ShouldReturnFalse()
        {
            var playerSequence = new PlayerSequence();
            Assert.That(playerSequence.IsCurrentPlayer("me"), Is.False);            
        }

        [Test]
        public void GivenPlayerSequenceWithOnePlayer_FirstPlayerShouldBePlayer()
        {
            var playerSequence = new PlayerSequence();
            const string playerName = "me";
            playerSequence.AddPlayer(playerName);

            Assert.That(playerSequence.IsCurrentPlayer(playerName), Is.True);
        }

        [Test]
        public void GivenPlayerSequenceWithOnePlayer_SecondPlayerShouldBePlayer()
        {
            var playerSequence = new PlayerSequence();
            const string playerName = "me";
            playerSequence.AddPlayer(playerName);

            playerSequence.AdvanceToNextPlayer();

            Assert.That(playerSequence.IsCurrentPlayer(playerName), Is.True);
        }

    }
}

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
        public void GivenPlayerSequenceWithOnePlayer_FirstTurnShouldBelongToPlayer()
        {
            var playerSequence = new PlayerSequence();
            const string playerName = "me";
            playerSequence.AddPlayer(playerName);

            Assert.That(playerSequence.IsCurrentPlayer(playerName), Is.True);
        }

        [Test]
        public void GivenPlayerSequenceWithOnePlayer_SecondTurnShouldBelongToPlayer()
        {
            var playerSequence = new PlayerSequence();
            const string playerName = "me";
            playerSequence.AddPlayer(playerName);

            playerSequence.AdvanceToNextPlayer();

            Assert.That(playerSequence.IsCurrentPlayer(playerName), Is.True);
        }

        [Test]
        public void GivenPlayerSequenceWithTwoPlayers_FirstTurnShouldBelongToPlayer1()
        {
            var playerSequence = new PlayerSequence();
            const string playerName1 = "player1";
            const string playerName2 = "player2";
            playerSequence.AddPlayer(playerName1);
            playerSequence.AddPlayer(playerName2);

            Assert.That(playerSequence.IsCurrentPlayer(playerName1), Is.True);
        }

        [Test]
        public void GivenPlayerSequenceWithTwoPlayers_SecondTurnShouldBelongToPlayer2()
        {
            var playerSequence = new PlayerSequence();
            const string playerName1 = "player1";
            const string playerName2 = "player2";
            playerSequence.AddPlayer(playerName1);
            playerSequence.AddPlayer(playerName2);

            playerSequence.AdvanceToNextPlayer();

            Assert.That(playerSequence.IsCurrentPlayer(playerName2), Is.True);
        }

        [Test]
        public void GivenPlayerSequenceWithTwoPlayers_ThirdTurnShouldBelongToPlayer1()
        {
            var playerSequence = new PlayerSequence();
            const string playerName1 = "player1";
            const string playerName2 = "player2";
            playerSequence.AddPlayer(playerName1);
            playerSequence.AddPlayer(playerName2);

            playerSequence.AdvanceToNextPlayer();
            playerSequence.AdvanceToNextPlayer();

            Assert.That(playerSequence.IsCurrentPlayer(playerName1), Is.True);
        }

        [Test]
        public void GivenPlayerSequenceWithTwoPlayers_CallingCurrentPlayer_ShouldNotChangeWhoseTurnComesSecond()
        {
            var playerSequence = new PlayerSequence();
            const string playerName1 = "player1";
            const string playerName2 = "player2";
            playerSequence.AddPlayer(playerName1);
            playerSequence.AddPlayer(playerName2);

            playerSequence.IsCurrentPlayer("notAPlayer");
            playerSequence.AdvanceToNextPlayer();

            Assert.That(playerSequence.IsCurrentPlayer(playerName2), Is.True);
        }

    }
}

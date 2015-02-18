using NUnit.Framework;

namespace ConsoleBasedGame.Tests
{
    [TestFixture]
    public class PlayerInfoTests
    {
        [Test]
        public void TwoPlayerInfosWithSameValuesAreEqual()
        {
            // ARRANGE, ACT
            var player1 = new PlayerInfo("playerName", 'a', 'b');
            var player2 = new PlayerInfo("playerName", 'a', 'b');

            // ASSERT
            Assert.That(player1, Is.EqualTo(player2));
        } 
    }
}

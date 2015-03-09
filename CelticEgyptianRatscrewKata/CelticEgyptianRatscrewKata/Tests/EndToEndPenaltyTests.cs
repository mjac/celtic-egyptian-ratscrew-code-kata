using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.GameSetup;
using CelticEgyptianRatscrewKata.SnapRules;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public class EndToEndPenaltyTests
    {
        [Test]
        public void SnappingWhenOnePlayerHasAPenaltyShouldFailIfSnapValid()
        {
            // ARRANGE
            var player1 = new Player("p1");
            var player2 = new Player("p2");
            var snapValidator = Substitute.For<ISnapValidator>();
            snapValidator.CanSnap(Arg.Any<Cards>()).Returns(false, true);

            var gameController = new GameController(new GameState(), snapValidator, Substitute.For<IDealer>(), Substitute.For<IShuffler>());
            gameController.AddPlayer(player1);
            gameController.AddPlayer(player2);

            // ACT
            // Get a penalty
            gameController.AttemptSnap(player1);
            // Try a `valid` snap
            var success = gameController.AttemptSnap(player1);

            // ASSERT
            Assert.IsFalse(success, "The snap should not succeed");
        }
    }
}

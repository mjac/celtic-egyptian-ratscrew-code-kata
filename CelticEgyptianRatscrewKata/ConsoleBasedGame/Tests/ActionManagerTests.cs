using CelticEgyptianRatscrewKata.Game;
using NSubstitute;
using NUnit.Framework;

namespace ConsoleBasedGame.Tests
{
    [TestFixture]
    public class ActionManagerTests
    {
        private IGameController _gameController;
        private ActionManager _actionManager;

        [SetUp]
        public void SetUp()
        {
            _gameController = Substitute.For<IGameController>();
            _actionManager = new ActionManager(_gameController);
        }

        [Test]
        public void DoesNothingWhenNoKeysBound()
        {
            // ACT
            _actionManager.Process('a');

            // ASSERT
            _gameController.DidNotReceive().AttemptSnap(Arg.Any<IPlayer>());
            _gameController.DidNotReceive().PlayCard(Arg.Any<IPlayer>());
        }
    }
}

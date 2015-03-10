using CelticEgyptianRatscrewKata.GameSetup;
using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Game
{
    public class RatscrewGameFactory : IGameFactory
    {
        public IGameController Create(ILog log)
        {
            ICardSnapRule[] rules =
            {
                new DarkQueenCardSnapRule(),
                new SandwichCardSnapRule(),
                new StandardCardSnapRule(),
            };

            var gameController = new GameController(new GameState(), new SnapValidator(rules), new Dealer(), new Shuffler());
            return new LoggedGameController(gameController, log);
        }
    }
}
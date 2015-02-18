using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    /// <summary>
    /// Maps key bindings to actions on an <see cref="IGameController"/>.
    /// </summary>
    internal class ActionManager
    {
        private readonly IGameController _gameController;

        public ActionManager(IGameController gameController)
        {
            _gameController = gameController;
        }

        public void Process(char input)
        {

        }

        public void Bind(PlayerInfo playerInfo)
        {

        }
    }
}
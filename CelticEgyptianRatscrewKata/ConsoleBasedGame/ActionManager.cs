using System;
using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    /// <summary>
    /// Maps key bindings to actions on an <see cref="IGameController"/>.
    /// </summary>
    internal class ActionManager
    {
        private readonly IDictionary<char, Action> _keyBindings;
        private readonly IGameController _gameController;

        public ActionManager(IGameController gameController)
        {
            _keyBindings = new Dictionary<char, Action>();
            _gameController = gameController;
        }

        public void Process(char input)
        {
            if (_keyBindings.ContainsKey(input))
            {
                var action = _keyBindings[input];
                action();
            }
        }

        public void Bind(PlayerInfo playerInfo)
        {
            _keyBindings.Add(playerInfo.SnapKey, () => _gameController.AttemptSnap(playerInfo));
        }
    }
}
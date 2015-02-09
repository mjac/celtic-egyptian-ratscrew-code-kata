using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Game
{
    /// <summary>
    /// Controls a game of Celtic Egyptian Ratscrew.
    /// </summary>
    public class GameController
    {
        private readonly SnapValidator _snapValidator;
        private readonly IList<IPlayer> _players;
        private readonly GameState _gameState;

        public GameController(SnapValidator snapValidator)
        {
            _players = new List<IPlayer>();
            _gameState = new GameState();
            _snapValidator = snapValidator;
        }

        public bool AddPlayer(IPlayer player)
        {
            if (_players.Any(x => x.Name == player.Name)) return false;

            _players.Add(player);
            _gameState.AddPlayer(player.Name, Cards.Empty());
            return true;
        }
    }
}
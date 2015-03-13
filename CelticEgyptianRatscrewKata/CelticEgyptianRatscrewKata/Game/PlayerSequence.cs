using System;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Game
{
    public class PlayerSequence : IPlayerSequence
    {
        private Dictionary<string, string> _nextPlayerMapping = new Dictionary<string, string>();
        private string _currentPlayer;

        public void AddPlayer(string name)
        {
            var alreadyPlaying = _nextPlayerMapping.Keys;
            var all = alreadyPlaying.Concat(new[] { name });
            SetPlayerSequence(all.ToList());
        }

        public void AdvanceToNextPlayer()
        {
            SetTheFirstPlayerIfItsNotAlreadyBeenDone();
            _currentPlayer = _currentPlayer == null ? null : _nextPlayerMapping[_currentPlayer];
        }

        public bool IsCurrentPlayer(string name)
        {
            SetTheFirstPlayerIfItsNotAlreadyBeenDone();
            return _currentPlayer == name;
        }

        private void SetTheFirstPlayerIfItsNotAlreadyBeenDone()
        {
            if (_currentPlayer == null && _nextPlayerMapping.Count > 0)
            {
                _currentPlayer = _nextPlayerMapping.Keys.First();
            }
        }

        private void SetPlayerSequence(IList<string> players)
        {
            _nextPlayerMapping = players
                .Zip(players.Skip(1), Tuple.Create)
                .Concat(new[] {Tuple.Create(players.Last(), players.First())})
                .ToDictionary(x => x.Item1, x => x.Item2);
        }
    }

}
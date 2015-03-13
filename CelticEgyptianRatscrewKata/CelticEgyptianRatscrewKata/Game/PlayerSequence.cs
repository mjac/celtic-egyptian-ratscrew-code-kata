using System;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Game
{
    public class PlayerSequence
    {
        private Dictionary<string, string> _nextPlayerMapping = new Dictionary<string, string>();

        public PlayerSequence()
        {
        }

        public string CurrentPlayer { get; set; }

        public void AddPlayer(string name)
        {
            var alreadyPlaying = _nextPlayerMapping.Keys;
            var all = alreadyPlaying.Concat(new[] { name });
            SetPlayerSequence(all.ToList());
        }

        public void SetNextPlayer(string player)
        {
            CurrentPlayer = _nextPlayerMapping[player];
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
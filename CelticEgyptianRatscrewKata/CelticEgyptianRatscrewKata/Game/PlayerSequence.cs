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

        public void SetPlayerSequence(IList<string> players)
        {
            _nextPlayerMapping = players
                .Zip(players.Skip(1), Tuple.Create)
                .Concat(new[] {Tuple.Create(players.Last(), players.First())})
                .ToDictionary(x => x.Item1, x => x.Item2);
        }

        public void SetNextPlayer(string player)
        {
            CurrentPlayer = _nextPlayerMapping[player];
        }
    }

}
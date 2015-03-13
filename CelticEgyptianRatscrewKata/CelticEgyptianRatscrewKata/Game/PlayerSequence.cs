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

        public void SetPlayerSequence(IList<IPlayer> players)
        {
            _nextPlayerMapping = players
                .Zip(players.Skip(1), Tuple.Create)
                .Concat(new[] {Tuple.Create(players.Last(), players.First())})
                .ToDictionary(x => x.Item1.Name, x => x.Item2.Name);
        }

        public void SetNextPlayer(IPlayer player)
        {
            CurrentPlayer = _nextPlayerMapping[player.Name];
        }
    }
}
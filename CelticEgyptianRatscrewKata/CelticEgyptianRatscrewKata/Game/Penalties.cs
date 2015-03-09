using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Game
{
    public class Penalties : IPenalties
    {
        private readonly IDictionary<IPlayer, bool> _hasPenalty;

        public Penalties()
        {
            _hasPenalty = new Dictionary<IPlayer, bool>();
        }

        public void AddPlayer(IPlayer player)
        {
            _hasPenalty.Add(player, false);
        }

        public bool HasPenalty(IPlayer player)
        {
            return _hasPenalty[player];
        }

        public void ClearPenalties()
        {
            foreach (var player in _hasPenalty.Keys.ToList())
            {
                _hasPenalty[player] = false;
            }
        }

        public void GivePenalty(IPlayer player)
        {
            _hasPenalty[player] = true;
            if (_hasPenalty.All(kvp => kvp.Value))
            {
                ClearPenalties();
            }
        }
    }
}
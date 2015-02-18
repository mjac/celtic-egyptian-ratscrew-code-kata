using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    internal class PlayerInfo :IPlayer
    {
        public string Name { get; private set; }
        public char PlayCardKey { get; private set; }
        public char SnapKey { get; private set; }

        public PlayerInfo(string name, char playCardKey, char snapKey)
        {
            SnapKey = snapKey;
            Name = name;
            PlayCardKey = playCardKey;
        }
    }
}
namespace CelticEgyptianRatscrewKata.Game
{
    public class Player : IPlayer
    {
        public Player(string playerId)
        {
            Name = playerId;
        }

        public string Name { get; private set; }
        public bool HasPenalty { get; set; }
    }
}
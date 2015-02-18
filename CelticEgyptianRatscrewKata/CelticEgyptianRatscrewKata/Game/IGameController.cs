namespace CelticEgyptianRatscrewKata.Game
{
    public interface IGameController
    {
        bool AddPlayer(IPlayer player);
        void PlayCard(IPlayer player);
        void AttemptSnap(IPlayer player);

        /// <summary>
        /// Starts a game with the currently added players
        /// </summary>
        void StartGame(Cards deck);

        bool TryGetWinner(out IPlayer winner);
    }
}
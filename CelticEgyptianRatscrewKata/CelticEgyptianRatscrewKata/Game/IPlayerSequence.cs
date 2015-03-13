namespace CelticEgyptianRatscrewKata.Game
{
    public interface IPlayerSequence
    {
        string CurrentPlayer { get; }
        void AddPlayer(string name);
        void AdvanceToNextPlayer();
    }
}
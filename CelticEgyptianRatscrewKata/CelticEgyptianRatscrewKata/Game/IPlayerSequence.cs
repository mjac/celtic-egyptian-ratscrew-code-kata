namespace CelticEgyptianRatscrewKata.Game
{
    public interface IPlayerSequence
    {
        void AddPlayer(string name);
        void AdvanceToNextPlayer();
        bool IsCurrentPlayer(string name);
    }
}
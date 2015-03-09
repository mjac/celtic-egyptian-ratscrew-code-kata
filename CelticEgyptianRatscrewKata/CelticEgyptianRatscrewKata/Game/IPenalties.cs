namespace CelticEgyptianRatscrewKata.Game
{
    public interface IPenalties
    {
        void AddPlayer(IPlayer player);
        bool HasPenalty(IPlayer player);
        void ClearPenalties();
        void GivePenalty(IPlayer player);
    }
}
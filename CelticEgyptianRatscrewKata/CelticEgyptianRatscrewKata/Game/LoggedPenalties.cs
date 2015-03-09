namespace CelticEgyptianRatscrewKata.Game
{
    public class LoggedPenalties : IPenalties
    {
        private readonly IPenalties _penalties;
        private readonly ILog _log;

        public LoggedPenalties(IPenalties penalties, ILog log)
        {
            _penalties = penalties;
            _log = log;
        }

        public void AddPlayer(IPlayer player)
        {
            _penalties.AddPlayer(player);
        }

        public bool HasPenalty(IPlayer player)
        {
            return _penalties.HasPenalty(player);
        }

        public void ClearPenalties()
        {
            _penalties.ClearPenalties();
        }

        public void GivePenalty(IPlayer player)
        {
            _penalties.GivePenalty(player);
        }
    }
}

using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.CallingOut
{
    public class PlayerSequenceWithCallingOut : IPlayerSequence
    {
        private readonly IPlayerSequence m_PlayerSequence;
        private readonly ICallOutAdvancer m_CallOutAdvancer;

        public PlayerSequenceWithCallingOut(IPlayerSequence playerSequence, ICallOutAdvancer callOutAdvancer)
        {
            m_PlayerSequence = playerSequence;
            m_CallOutAdvancer = callOutAdvancer;
        }

        public void AddPlayer(string name)
        {
            m_PlayerSequence.AddPlayer(name);
        }

        public void AdvanceToNextPlayer()
        {
            m_PlayerSequence.AdvanceToNextPlayer();
            m_CallOutAdvancer.AdvanceRank();
        }

        public bool IsCurrentPlayer(string name)
        {
            return m_PlayerSequence.IsCurrentPlayer(name);
        }
    }
}

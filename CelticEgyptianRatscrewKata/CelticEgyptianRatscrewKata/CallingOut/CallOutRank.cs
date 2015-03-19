using System;

namespace CelticEgyptianRatscrewKata.CallingOut
{
    public class CallOutRank : ICalledRankProvider, ICallOutAdvancer
    {
        private readonly Rank[] m_Ranks = (Rank[])Enum.GetValues(typeof(Rank));

        private Rank m_CurrentRank;

        public CallOutRank(Rank startRank)
        {
            m_CurrentRank = startRank;
        }

        public Rank GetCurrentRank()
        {
            return m_CurrentRank;
        }

        public void AdvanceRank()
        {
            var currentRankIndex = Array.IndexOf(m_Ranks, m_CurrentRank);

            var nextRankIndex = (currentRankIndex + 1) % m_Ranks.Length;

            m_CurrentRank = m_Ranks[nextRankIndex];
        }
    }
}

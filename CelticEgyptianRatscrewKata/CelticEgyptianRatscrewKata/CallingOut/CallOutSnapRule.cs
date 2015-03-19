using System.Linq;
using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.CallingOut
{
    public class CallOutSnapRule : ISnapRule
    {
        private readonly ICalledRankProvider m_CalledRankProvider;

        public CallOutSnapRule(ICalledRankProvider calledRankProvider)
        {
            m_CalledRankProvider = calledRankProvider;
        }

        public bool IsSnapValid(Cards cardStack)
        {
            var topCard = cardStack.FirstOrDefault();
            if (topCard != null && topCard.Rank == m_CalledRankProvider.GetCurrentRank())
            {
                return true;
            }

            return false;
        }
    }
}

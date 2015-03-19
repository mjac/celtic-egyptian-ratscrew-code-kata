using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelticEgyptianRatscrewKata.CallingOut
{
    public class CallOutRank : ICalledRankProvider
    {
        public Rank GetCurrentRank()
        {
            return Rank.Ace;
        }
    }
}

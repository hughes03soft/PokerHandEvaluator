using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.FiveCards
{
    public class RoyalFlushEvaluator : StraightFlushEvaluator
    {
        public new string Description => "Royal Flush";
        protected new int MajorRankScore => (int)FiveCardPokerEvaluator.HandRank.StraightFlush;
    }
}

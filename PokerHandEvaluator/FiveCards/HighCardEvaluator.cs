using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.FiveCards
{
    public class HighCardEvaluator : IHandEvaluator
    {
        public string Description => "High Card";

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = (int)FiveCardPokerEvaluator.HandRank.HighCard +
                            (int)hand.MaxCardValue;

            return rankScore;
        }

        public bool IsValidCombination(Hand hand)
        {
            return true;
        }
    }
}

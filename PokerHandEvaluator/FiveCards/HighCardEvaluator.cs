using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.FiveCards
{
    public class HighCardEvaluator : IHandEvaluator
    {
        const int EXPECTED_UNIQUE_CARD_VALUES = 5;
        public string Description => "High Card";

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = (int)FiveCardPokerEvaluator.HandRank.HighCard +
                            (int)hand.HighestCardValue;

            return rankScore;
        }

        public bool IsValidCombination(Hand hand)
        {
            return hand.UniqueCardValues.Count == EXPECTED_UNIQUE_CARD_VALUES;
        }
    }
}

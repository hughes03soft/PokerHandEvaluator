using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.FiveCards
{
    public class ThreeOfAKindEvaluator : IHandEvaluator
    {
        private const int EXPECTED_UNIQUE_CARD_VALUES = 3;
        private const int EXPECTED_MAX_DUPLICATE_COUNT = 3;
        public string Description => "Three of a Kind";
        public bool IsValidCombination(Hand hand)
        {
            return hand.UniqueCardValues.Count == EXPECTED_UNIQUE_CARD_VALUES &&
                   hand.CardValueCount(hand.CardValueOfMaxDuplicateCount) == EXPECTED_MAX_DUPLICATE_COUNT;
        }

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = (int)FiveCardPokerEvaluator.HandRank.ThreeOfAKind |
                            (int)hand.CardValueOfMaxDuplicateCount;

            return rankScore;
        }
    }
}

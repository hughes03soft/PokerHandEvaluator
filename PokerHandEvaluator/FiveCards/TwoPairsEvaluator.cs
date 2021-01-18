using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.FiveCards
{
    public class TwoPairsEvaluator : IHandEvaluator
    {
        private const int EXPECTED_UNIQUE_CARD_VALUES = 3;
        private const int EXPECTED_MAX_DUPLICATE_COUNT = 2;
        public string Description => "Two Pairs";

        public bool IsValidCombination(Hand hand)
        {
            return hand.UniqueCardValues.Count == EXPECTED_UNIQUE_CARD_VALUES &&
                   hand.CardValueCount(hand.CardValueOfMaxDuplicateCount) == EXPECTED_MAX_DUPLICATE_COUNT;
        }

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = (int)FiveCardPokerEvaluator.HandRank.TwoPairs;
            //highest 2 msb is currently free
            // shift left CardValue once for the pairs
            // rankScore = shifted(1) + non-pair

            foreach (var value in hand.UniqueCardValues)
            {
                if (hand.CardValueCount(value) == EXPECTED_MAX_DUPLICATE_COUNT)
                {
                    rankScore |= ((int)value << 1);
                }
                else
                {
                    rankScore |= (int)value;
                }
            }

            return rankScore;
        }


    }
}

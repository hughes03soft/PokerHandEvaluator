using System.Collections.Generic;

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

            //16-bit representation, 4 bits each
            //empty | 1st Pair | 2nd Pair | High Card

            const int bitWidth = 4;
            int shifts = bitWidth;

            SortedSet<Card.Values> sortedCardValues = new SortedSet<Card.Values>(hand.UniqueCardValues);

            //expecting just 3 items and getting lowest pair first before the highest pair
            foreach (var value in sortedCardValues)
            {
                if (hand.CardValueCount(value) == EXPECTED_MAX_DUPLICATE_COUNT)
                {
                    rankScore |= (value.ToNumberValue() << shifts);
                    shifts += bitWidth;
                }
                else
                {
                    rankScore |= value.ToNumberValue();
                }
            }

            return rankScore;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.FiveCards
{
    public class OnePairEvaluator : IHandEvaluator
    {
        private const int EXPECTED_UNIQUE_CARD_VALUES = 4;
        private const int EXPECTED_MAX_DUPLICATE_COUNT = 2;
        public string Description => "One Pair";
        public bool IsValidCombination(Hand hand)
        {
            return hand.UniqueCardValues.Count == EXPECTED_UNIQUE_CARD_VALUES &&
                   hand.CardValueCount(hand.CardValueOfMaxDuplicateCount) == EXPECTED_MAX_DUPLICATE_COUNT;
        }

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = (int)FiveCardPokerEvaluator.HandRank.OnePair;

            //16-bit representation, 4 bits each
            //1stPair | 1st HiCard | 2nd HiCard | 3rd High Card

            const int firstPairShift = 12;
            const int bitWidth = 4;
            int shifts = 0;

            SortedSet<Card.Values> sortedCardValues = new SortedSet<Card.Values>(hand.UniqueCardValues);

            //expecting just 3 items and getting lowest pair first before the highest pair
            foreach (var value in sortedCardValues)
            {
                if (hand.CardValueCount(value) == EXPECTED_MAX_DUPLICATE_COUNT)
                {
                    rankScore |= (value.ToNumberValue() << firstPairShift);
                }
                else
                {
                    rankScore |= (value.ToNumberValue() << shifts);
                    shifts += bitWidth;
                }
            }

            return rankScore;
        }
    }
}

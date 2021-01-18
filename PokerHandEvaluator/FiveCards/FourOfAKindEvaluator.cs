namespace PokerHandEvaluator.FiveCards
{
    public class FourOfAKindEvaluator : IHandEvaluator
    {
        private int EXPECTED_UNIQUE_CARD_VALUES = 2;
        private int EXPECTED_MAX_DUPLICATE_COUNT = 4;
        public string Description => "Four of a Kind";
        public bool IsValidCombination(Hand hand)
        {
            return hand.UniqueCardValues.Count == EXPECTED_UNIQUE_CARD_VALUES &&
                   hand.CardValueCount(hand.CardValueOfMaxDuplicateCount) == EXPECTED_MAX_DUPLICATE_COUNT;
        }

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = (int)FiveCardPokerEvaluator.HandRank.FourOfAKind | 
                            (int)hand.CardValueOfMaxDuplicateCount;

            return rankScore;
        }
    }
}

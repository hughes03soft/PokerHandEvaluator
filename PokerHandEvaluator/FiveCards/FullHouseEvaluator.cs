namespace PokerHandEvaluator.FiveCards
{
    public class FullHouseEvaluator : IHandEvaluator
    {
        private const int EXPECTED_UNIQUE_CARD_VALUES = 2;
        private const int EXPECTED_MAX_DUPLICATE_COUNT = 3;
        public string Description => "Full House";
        public bool IsValidCombination(Hand hand)
        {
            return hand.UniqueCardValues.Count == EXPECTED_UNIQUE_CARD_VALUES &&
                   hand.CardValueCount(hand.CardValueOfMaxDuplicateCount) == EXPECTED_MAX_DUPLICATE_COUNT;
        }

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = (int)FiveCardPokerEvaluator.HandRank.FullHouse |
                            (int)hand.CardValueOfMaxDuplicateCount;

            return rankScore;
        }
    }
}

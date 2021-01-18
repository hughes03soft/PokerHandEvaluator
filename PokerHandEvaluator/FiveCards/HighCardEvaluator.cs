namespace PokerHandEvaluator.FiveCards
{
    public class HighCardEvaluator : IHandEvaluator
    {
        private const int EXPECTED_UNIQUE_CARD_VALUES = 5;
        public string Description => "High Card";

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = (int)FiveCardPokerEvaluator.HandRank.HighCard |
                            (int)hand.OredCardValues;

            return rankScore;
        }

        public bool IsValidCombination(Hand hand)
        {
            return hand.UniqueCardValues.Count == EXPECTED_UNIQUE_CARD_VALUES;
        }
    }
}

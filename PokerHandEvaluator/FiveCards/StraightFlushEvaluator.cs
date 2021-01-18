namespace PokerHandEvaluator.FiveCards
{
    public class StraightFlushEvaluator : IHandEvaluator
    {
        protected int MajorRankScore => (int)FiveCardPokerEvaluator.HandRank.StraightFlush;
        public string Description => "Straight Flush";

        public bool IsValidCombination(Hand hand)
        {
            var straight = new StraightEvaluator();
            var flush = new FlushEvaluator();

            return straight.IsValidCombination(hand) && flush.IsValidCombination(hand);
        }

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = MajorRankScore + (int)hand.HighestCardValue;

            return rankScore;
        }


    }
}

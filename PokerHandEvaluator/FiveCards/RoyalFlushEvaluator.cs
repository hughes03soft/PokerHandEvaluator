namespace PokerHandEvaluator.FiveCards
{
    public class RoyalFlushEvaluator : StraightFlushEvaluator
    {
        public new string Description => "Royal Flush";
        protected new int MajorRankScore => (int)FiveCardPokerEvaluator.HandRank.StraightFlush;
    }
}

using System;

namespace PokerHandEvaluator.FiveCards
{
    public class FlushEvaluator : IHandEvaluator
    {
        public string Description => "Flush";

        public bool IsValidCombination(Hand hand)
        {
            int andedSuites = 0xFFFF;

            foreach (var card in hand.Cards)
                andedSuites &= (int)card.Suite;

            if ((andedSuites & Card.SUITE_MASK) > 0)
                return true;

            return false;
        }

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = (int)FiveCardPokerEvaluator.HandRank.Flush +
                            (int)hand.Cards.Max();

            return rankScore;
        }
    }
}

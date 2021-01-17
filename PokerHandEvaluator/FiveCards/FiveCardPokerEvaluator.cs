using System.Collections.Generic;
using System.Linq;

namespace PokerHandEvaluator.FiveCards
{
    public class FiveCardPokerEvaluator
    {
        public enum HandRank
        {
            HighCard        = 1 << 16,
            OnePair         = 1 << 17,
            TwoPairs        = 1 << 18,
            ThreeOfAKind    = 1 << 19,
            Straight        = 1 << 20,
            Flush           = 1 << 21,
            FullHouse       = 1 << 22,
            FourOfAKind     = 1 << 23,
            StraightFlush   = 1 << 24,
            RoyalFlush      = 1 << 25
        };

        private List<IHandEvalutor> Evaluators = new List<IHandEvalutor>();

        public FiveCardPokerEvaluator()
        {
            //add evaluators starting from the highest rank
            Evaluators.Add(new FlushEvaluator());
        }

        private Hand CreateHand(string owner, string[] cards)
        {
            Hand hand = new Hand(owner, cards);

            foreach (IHandEvalutor evaluator in Evaluators)
            {
                if (evaluator.IsValidCombination(hand))
                {
                    hand.Description = evaluator.Description;
                    hand.RankScore = evaluator.CalculateRankScore(hand);
                    break;
                }
            }

            return hand;
        }

        public List<Hand> GetWinners(string owner, string[] cards)
        {
            var hands = new List<Hand>();

            foreach (var card in cards)
            {
                hands.Add(new Hand(owner, cards));
            }

            int maxRankScore = hands.Max(h => h.RankScore);
            var winners = hands.Where(h => h.RankScore == maxRankScore).ToList();

            return winners;
        }
    }

    public static class FiveCardPokerCardExt
    {
        public static Card.Values Max(this List<Card> cards)
        {
            //revise
            Card.Values min = Card.Values.Two;

            foreach (var card in cards)
                if (card.Value > min)
                    min = card.Value;

            return min;
        }
    }
}

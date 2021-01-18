using System.Collections.Generic;
using System.Linq;
using System;

namespace PokerHandEvaluator.FiveCards
{
    public class FiveCardPokerEvaluator
    {
        // HandRank Bit Representation
        // x|x|x|x|x|RF|SF|FK|FH|F|S|TK|TP|OP|HC|~lower 16 bits for SubRankScore~
        public enum HandRank
        {
            RoyalFlush      = 1 << 25,
            StraightFlush   = 1 << 24,
            FourOfAKind     = 1 << 23,
            FullHouse       = 1 << 22,
            Flush           = 1 << 21,
            Straight        = 1 << 20,
            ThreeOfAKind    = 1 << 19,
            TwoPairs        = 1 << 18,
            OnePair         = 1 << 17,
            HighCard        = 1 << 16
        };

        //add evaluators starting from the highest rank
        //if not, evaluation might be wrong.
        //
        //For example, StraightEvaluator will check only for 5 consecutive cards
        //regardless of suite. If the StraightEvaluator is run first before the
        //RoyalFlushEvaluator, a royal flush hand, which has 5 consecutive cards,
        //will be evaluated as just a straight

        private List<IHandEvaluator> Evaluators = new List<IHandEvaluator>()
        {
            new RoyalFlushEvaluator(),
            new StraightFlushEvaluator(),
            new FourOfAKindEvaluator(),
            new FullHouseEvaluator(),
            new FlushEvaluator(),
            new StraightEvaluator(), 
            new ThreeOfAKindEvaluator(),
            new TwoPairsEvaluator(),
            new OnePairEvaluator(),
            new HighCardEvaluator()
        };

        public FiveCardPokerEvaluator()
        {

        }

        private Hand CreateHand(string owner, string[] cards)
        {
            Hand hand = new Hand(owner, cards);

            foreach (IHandEvaluator evaluator in Evaluators)
            {
                if (evaluator.IsValidCombination(hand))
                {
                    hand.Description = evaluator.Description;
                    hand.RankScore = evaluator.CalculateRankScore(hand);
                    break;
                }
            }

            if (hand.RankScore == 0)
                throw new ArgumentException("Card Combination Not Found");

            return hand;
        }

        public List<Hand> GetWinners(string owner, string[] cards)
        {
            var hands = new List<Hand>();

            foreach (var card in cards)
            {
                hands.Add(CreateHand(owner, cards));
            }

            int maxRankScore = hands.Max(h => h.RankScore);
            var winners = hands.Where(h => h.RankScore == maxRankScore).ToList();

            return winners;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.FiveCards
{
    public class StraightEvaluator : IHandEvaluator
    {
        public string Description => "Straight";

        public bool IsValidCombination(Hand hand)
        {
            int fiveCardStraightMask = 0b11111;
            const int maskLength = 5;
            const int bit0AndOffset = 2;
            bool isValid = false;
            for(int i = 0; i < Enum.GetNames(typeof(Card.Values)).Length + bit0AndOffset - maskLength; i++)
            {
                if ((hand.OredCardValues & fiveCardStraightMask) == fiveCardStraightMask)
                {
                    isValid = true;
                    break;
                }

                fiveCardStraightMask <<= 1;
            }

            return isValid;
        }

        public int CalculateRankScore(Hand hand)
        {
            int rankScore = (int)FiveCardPokerEvaluator.HandRank.Straight;

            const int FiveToAceMask = 0b11111;
            if ((hand.OredCardValues & FiveToAceMask) == FiveToAceMask)
                rankScore += (int)Card.Values.Five; 
            else
                rankScore += (int)hand.Cards.Max(); 

            return rankScore;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.FiveCards
{
    public class StraightEvaluator : IHandEvalutor
    {
        public string Description => "Straight";

        public bool IsValidCombination(Hand hand)
        {
            int oredValues = 0;

            foreach(var card in hand.Cards)
                oredValues |= (int)card.Value;

            int fiveCardStraightMask = 0b11111;
            const int maskLength = 5;
            const int bit0AndOffset = 2;
            bool isValid = false;
            for(int i = 0; i < Enum.GetNames(typeof(Card.Values)).Length + bit0AndOffset - maskLength; i++)
            {
                if ((oredValues & fiveCardStraightMask) == fiveCardStraightMask)
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

            int oredValues = 0;
            foreach (var card in hand.Cards)
                oredValues |= (int)card.Value;

            const int FiveToAceMask = 0b11111;
            if ((oredValues & FiveToAceMask) == FiveToAceMask)
                rankScore += (int)Card.Values.Five; 
            else
                rankScore += (int)hand.Cards.Max(); 

            return rankScore;
        }
    }
}

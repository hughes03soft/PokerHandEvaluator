﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.FiveCards
{
    public class ThreeOfAKindEvaluator : IHandEvaluator
    {
        public string Description => "Three of a Kind";

        public bool IsValidCombination(Hand hand)
        {
            throw new NotImplementedException();
        }

        public int CalculateRankScore(Hand hand)
        {
            throw new NotImplementedException();
        }
    }
}

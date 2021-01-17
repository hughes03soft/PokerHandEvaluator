using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator
{
    public interface IHandEvalutor
    {
        string Description { get; }
        bool IsValidCombination(Hand hand);
        int CalculateRankScore(Hand hand);
    }
}

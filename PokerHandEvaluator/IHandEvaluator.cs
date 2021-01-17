namespace PokerHandEvaluator
{
    public interface IHandEvalutor
    {
        string Description { get; }
        bool IsValidCombination(Hand hand);
        int CalculateRankScore(Hand hand);
    }
}

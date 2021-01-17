namespace PokerHandEvaluator
{
    public interface IHandEvaluator
    {
        string Description { get; }
        bool IsValidCombination(Hand hand);
        int CalculateRankScore(Hand hand);
    }
}

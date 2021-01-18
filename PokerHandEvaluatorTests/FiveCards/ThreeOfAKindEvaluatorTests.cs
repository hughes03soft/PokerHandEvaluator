using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokerHandEvaluator.FiveCards.Tests
{
    [TestClass()]
    public class ThreeOfAKindEvaluatorTests
    {
        ThreeOfAKindEvaluator Eval = new ThreeOfAKindEvaluator();

        [DataTestMethod()]
        [DynamicData(nameof(GetIsValidCombinationTestData), DynamicDataSourceType.Method)]
        public void IsValidCombinationTest(Hand hand, bool expected)
        {
            bool actual = Eval.IsValidCombination(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetIsValidCombinationTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "3H", "4D", "9C", "9D", "QH" }), false };
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "AH", "AD", "10C" }), false };
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "7H", "9D", "9C" }), false };
            yield return new object[] { new Hand("Player1", new string[] { "AH", "AH", "AS", "KH", "7H" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "2C", "2H", "4H", "2D", "6H" }), true };
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetCalculateRankScoreTestData), DynamicDataSourceType.Method)]
        public void CalculateRankScoreTest(Hand hand, int expected)
        {
            int actual = Eval.CalculateRankScore(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetCalculateRankScoreTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "AH", "6D", "7C" }), (int)FiveCardPokerEvaluator.HandRank.ThreeOfAKind + (int)Card.Values.Ace };
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "7H", "6D", "5C" }), (int)FiveCardPokerEvaluator.HandRank.ThreeOfAKind + (int)Card.Values.Seven };
        }

        [TestMethod]
        public void FindLesserRank()
        {
            var lesserHand = new Hand("higherHand", new string[] { "10C", "10S", "10D", "2H", "KC" });
            var higherHand = new Hand("lesserHand", new string[] { "KS", "KD", "KH", "9D", "8S" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }
    }
}
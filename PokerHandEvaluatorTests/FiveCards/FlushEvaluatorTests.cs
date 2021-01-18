using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokerHandEvaluator.FiveCards.Tests
{
    [TestClass()]
    public class FlushEvaluatorTests
    {
        FlushEvaluator Eval = new FlushEvaluator();

        [DataTestMethod()]
        [DynamicData(nameof(GetIsValidCombinationTestData), DynamicDataSourceType.Method)]
        public void IsValidCombinationTest(Hand hand, bool expected)
        {
            bool actual = Eval.IsValidCombination(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetIsValidCombinationTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "AC", "3C", "6C", "KC", "7C" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "AS", "3S", "6S", "KS", "7S" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "AD", "3D", "6D", "KD", "7D" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "AH", "3H", "6H", "KH", "7H" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "AH", "3H", "6S", "KH", "7H" }), false };
            yield return new object[] { new Hand("Player1", new string[] { "AC", "3H", "6H", "KD", "7H" }), false };
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
            yield return new object[] { new Hand("Player1", new string[] { "AC", "3C", "6C", "KC", "7C" }), (int)FiveCardPokerEvaluator.HandRank.Flush + (int)Card.Values.Ace };
            yield return new object[] { new Hand("Player1", new string[] { "5S", "3S", "6S", "9S", "7S" }), (int)FiveCardPokerEvaluator.HandRank.Flush + (int)Card.Values.Nine };
        }

        [TestMethod]
        public void ResolveTieTest()
        {
            var lesserHand = new Hand("lesserHand", new string[] { "KS", "3S", "6S", "KS", "7S" });
            var higherHand = new Hand("higherHand", new string[] { "AC", "3C", "6C", "KC", "7C" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }

        [TestMethod]
        public void TieTest()
        {
            var hand1 = new Hand("hand1", new string[] { "AC", "3C", "6C", "KC", "7C" });
            var hand2 = new Hand("hand2", new string[] { "AS", "3S", "6S", "KS", "7S" });

            int rankScore1 = Eval.CalculateRankScore(hand1);
            int rankScore2 = Eval.CalculateRankScore(hand2);
            Assert.AreEqual(rankScore1, rankScore2);
        }
    }
}
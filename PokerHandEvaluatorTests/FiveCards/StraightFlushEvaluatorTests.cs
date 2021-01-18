using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokerHandEvaluator.FiveCards.Tests
{
    [TestClass()]
    public class StraightFlushEvaluatorTests
    {
        StraightFlushEvaluator Eval = new StraightFlushEvaluator();

        [DataTestMethod()]
        [DynamicData(nameof(GetIsValidCombinationTestData), DynamicDataSourceType.Method)]
        public void IsValidCombinationTest(Hand hand, bool expected)
        {
            bool actual = Eval.IsValidCombination(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetIsValidCombinationTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "KC", "QC", "JC", "10C", "9C" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "5S", "4S", "3S", "2S", "AS" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "KS", "QC", "JC", "10C", "9C" }), false };
            yield return new object[] { new Hand("Player1", new string[] { "KC", "QC", "JC", "7C", "9C" }), false };
        }

        [TestMethod()]
        public void CalculateRankScoreTest()
        {
            var hand = new Hand("Player1", new string[] { "KC", "QC", "JC", "10C", "9C" });
            int expected = (int)FiveCardPokerEvaluator.HandRank.StraightFlush + (int)Card.Values.King;
            int actual = Eval.CalculateRankScore(hand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLesserRank()
        {
            var lesserHand = new Hand("higherHand", new string[] { "2C", "3C", "4C", "5C", "6C" });
            var higherHand = new Hand("lesserHand", new string[] { "KS", "QS", "JS", "10S", "9S" });

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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandEvaluator.FiveCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.FiveCards.Tests
{
    [TestClass()]
    public class StraightEvaluatorTests
    {
        StraightEvaluator Eval = new StraightEvaluator();

        [DataTestMethod()]
        [DynamicData(nameof(GetIsValidCombinationTestData), DynamicDataSourceType.Method)]
        public void IsValidCombinationTest(Hand hand, bool expected)
        {
            bool actual = Eval.IsValidCombination(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetIsValidCombinationTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "AC", "KC", "QC", "JC", "10C" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "5S", "4S", "3S", "2S", "AS" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "KD", "JD", "10D", "QD", "AD" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "2H", "4H", "5H", "3H", "6H" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "AH", "3H", "6S", "KH", "7H" }), false };
            yield return new object[] { new Hand("Player1", new string[] { "2C", "3H", "4H", "KD", "6H" }), false };
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
            yield return new object[] { new Hand("Player1", new string[] { "AC", "KC", "QC", "JC", "10C" }), (int)FiveCardPokerEvaluator.HandRank.Straight + (int)Card.Values.Ace };
            yield return new object[] { new Hand("Player1", new string[] { "5S", "4S", "3S", "2S", "AS" }), (int)FiveCardPokerEvaluator.HandRank.Straight + (int)Card.Values.Five };
        }

        [TestMethod]
        public void FindLesserRank()
        {
            var lesserHand = new Hand("higherHand", new string[] { "AC", "2C", "3C", "5C", "4C" });
            var higherHand = new Hand("lesserHand", new string[] { "KS", "QH", "JS", "10S", "9S" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }

        [TestMethod]
        public void TieTest()
        {
            var hand1 = new Hand("hand1", new string[] { "AC", "3S", "6C", "KH", "7C" });
            var hand2 = new Hand("hand2", new string[] { "AS", "3S", "6D", "KS", "7S" });

            int rankScore1 = Eval.CalculateRankScore(hand1);
            int rankScore2 = Eval.CalculateRankScore(hand2);
            Assert.AreEqual(rankScore1, rankScore2);
        }
    }
}
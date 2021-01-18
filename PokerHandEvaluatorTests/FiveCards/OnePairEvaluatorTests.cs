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
    public class OnePairEvaluatorTests
    {
        OnePairEvaluator Eval = new OnePairEvaluator();

        [DataTestMethod()]
        [DynamicData(nameof(GetIsValidCombinationTestData), DynamicDataSourceType.Method)]
        public void IsValidCombinationTest(Hand hand, bool expected)
        {
            bool actual = Eval.IsValidCombination(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetIsValidCombinationTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "KH", "QD", "10C" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "3H", "6D", "JC" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "AH", "AH", "AS", "KH", "7H" }), false };
            yield return new object[] { new Hand("Player1", new string[] { "2C", "2H", "2H", "2D", "6H" }), false };
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
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "KH", "QD", "10C" }), 0x02DDCA};
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "3H", "6D", "JC" }), 0x027B63};
        }

        [TestMethod]
        public void FindLesserRank()
        {
            var lesserHand = new Hand("higherHand", new string[] { "8C", "8D", "3C", "5C", "4C" });
            var higherHand = new Hand("lesserHand", new string[] { "JS", "JH", "7S", "10S", "9S" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }

        [TestMethod]
        public void FindLesserRankTiedPair()
        {
            var lesserHand = new Hand("higherHand", new string[] { "8C", "8C", "3C", "5C", "4C" });
            var higherHand = new Hand("lesserHand", new string[] { "8S", "8H", "JS", "10S", "9S" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }

        [TestMethod]
        public void FindLesserRankTiedPairTiedHighCard()
        {
            var lesserHand = new Hand("higherHand", new string[] { "8C", "8C", "JC", "5C", "4C" });
            var higherHand = new Hand("lesserHand", new string[] { "8S", "8H", "JS", "2S", "9S" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }

        [TestMethod]
        public void FindLesserRankTiedPairTiedHighCardTiedSecondHighCard()
        {
            var lesserHand = new Hand("higherHand", new string[] { "8C", "8C", "JC", "5C", "4C" });
            var higherHand = new Hand("lesserHand", new string[] { "8S", "8H", "JS", "5S", "9S" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }

        [TestMethod]
        public void TieTest()
        {
            var hand1 = new Hand("hand1", new string[] { "8C", "8C", "JC", "5C", "4C" });
            var hand2 = new Hand("hand2", new string[] { "8S", "8H", "JS", "5S", "4S" });

            int rankScore1 = Eval.CalculateRankScore(hand1);
            int rankScore2 = Eval.CalculateRankScore(hand2);
            Assert.AreEqual(rankScore1, rankScore2);
        }
    }
}
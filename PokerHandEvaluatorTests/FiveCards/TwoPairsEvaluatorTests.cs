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
    public class TwoPairsEvaluatorTests
    {
        TwoPairsEvaluator Eval = new TwoPairsEvaluator();

        [DataTestMethod()]
        [DynamicData(nameof(GetIsValidCombinationTestData), DynamicDataSourceType.Method)]
        public void IsValidCombinationTest(Hand hand, bool expected)
        {
            bool actual = Eval.IsValidCombination(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetIsValidCombinationTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "KH", "KD", "10C" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "3H", "3D", "JC" }), true };
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
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "KH", "KD", "10C" }), (int)FiveCardPokerEvaluator.HandRank.TwoPairs + (((int)Card.Values.Ace << 1) | ((int)Card.Values.King << 1) | ((int)Card.Values.Ten)) };
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "3H", "3D", "JC" }), (int)FiveCardPokerEvaluator.HandRank.TwoPairs + (((int)Card.Values.Seven << 1) | ((int)Card.Values.Three << 1) | ((int)Card.Values.Jack)) };
        }

        [TestMethod]
        public void FindLesserRankFirstHighCard()
        {
            var lesserHand = new Hand("higherHand", new string[] { "QS", "QH", "JS", "JS", "9S" });
            var higherHand = new Hand("lesserHand", new string[] { "AS", "AC", "3C", "3D", "4H" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }

        [TestMethod]
        public void FindLesserRankFirstPairTied()
        {
            var lesserHand = new Hand("higherHand", new string[] { "AD", "AH", "JS", "JS", "9S" });
            var higherHand = new Hand("lesserHand", new string[] { "AS", "AC", "QC", "QD", "4H" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }

        [TestMethod]
        public void FindLesserRankFirstPairTiedSecondPairTied()
        {
            var lesserHand = new Hand("higherHand", new string[] { "AD", "AH", "QS", "QS", "9S" });
            var higherHand = new Hand("lesserHand", new string[] { "AS", "AC", "QC", "QD", "10H" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }

        [TestMethod]
        public void TieTest()
        {
            var hand1 = new Hand("hand1", new string[] { "AD", "AH", "QS", "QS", "9S" });
            var hand2 = new Hand("hand2", new string[] { "AS", "AC", "QC", "QD", "9C" });

            int rankScore1 = Eval.CalculateRankScore(hand1);
            int rankScore2 = Eval.CalculateRankScore(hand2);
            Assert.AreEqual(rankScore1, rankScore2);
        }
    }
}
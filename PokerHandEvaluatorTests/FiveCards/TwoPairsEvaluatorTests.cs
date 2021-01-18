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
        [DynamicData(nameof(GetCalculateRankScoreTestTestData), DynamicDataSourceType.Method)]
        public void CalculateRankScoreTest(Hand hand, int expected)
        {
            int actual = Eval.CalculateRankScore(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetCalculateRankScoreTestTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "KH", "KD", "10C" }), (int)FiveCardPokerEvaluator.HandRank.TwoPairs + (((int)Card.Values.Ace << 1) | ((int)Card.Values.King << 1) | ((int)Card.Values.Ten)) };
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "3H", "3D", "JC" }), (int)FiveCardPokerEvaluator.HandRank.TwoPairs + (((int)Card.Values.Seven << 1) | ((int)Card.Values.Three << 1) | ((int)Card.Values.Jack)) };
        }
    }
}
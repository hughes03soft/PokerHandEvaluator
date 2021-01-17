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
        [DynamicData(nameof(GetCalculateRankScoreTestTestData), DynamicDataSourceType.Method)]
        public void CalculateRankScoreTest(Hand hand, int expected)
        {
            int actual = Eval.CalculateRankScore(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetCalculateRankScoreTestTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "AC", "3C", "6C", "KC", "7C" }), (int)FiveCardPokerEvaluator.HandRank.Flush + (int)Card.Values.Ace };
            yield return new object[] { new Hand("Player1", new string[] { "5S", "3S", "6S", "9S", "7S" }), (int)FiveCardPokerEvaluator.HandRank.Flush + (int)Card.Values.Nine };
        }
    }
}
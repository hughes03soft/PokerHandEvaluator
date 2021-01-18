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
        [DynamicData(nameof(GetCalculateRankScoreTestTestData), DynamicDataSourceType.Method)]
        public void CalculateRankScoreTest(Hand hand, int expected)
        {
            int actual = Eval.CalculateRankScore(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetCalculateRankScoreTestTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "KH", "QD", "10C" }), (int)FiveCardPokerEvaluator.HandRank.OnePair + (((int)Card.Values.King) | ((int)Card.Values.Queen) | ((int)Card.Values.Ten))};
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "3H", "6D", "JC" }), (int)FiveCardPokerEvaluator.HandRank.OnePair + (((int)Card.Values.Three) | ((int)Card.Values.Six) | ((int)Card.Values.Jack)) };
        }
    }
}
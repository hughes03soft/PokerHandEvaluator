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
    public class FourOfAKindEvaluatorTests
    {
        FourOfAKindEvaluator Eval = new FourOfAKindEvaluator();

        [DataTestMethod()]
        [DynamicData(nameof(GetIsValidCombinationTestData), DynamicDataSourceType.Method)]
        public void IsValidCombinationTest(Hand hand, bool expected)
        {
            bool actual = Eval.IsValidCombination(hand);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetIsValidCombinationTestData()
        {
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "AH", "AD", "10C" }), true };
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "7H", "7D", "9C" }), true };
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
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "AH", "AD", "10C" }), (int)FiveCardPokerEvaluator.HandRank.FourOfAKind + (int)Card.Values.Ace };
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "7H", "7D", "9C" }), (int)FiveCardPokerEvaluator.HandRank.FourOfAKind + (int)Card.Values.Seven };
        }
    }
}
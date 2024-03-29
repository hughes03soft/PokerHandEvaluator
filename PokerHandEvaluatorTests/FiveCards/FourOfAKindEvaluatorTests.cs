﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            yield return new object[] { new Hand("Player1", new string[] { "AH", "AH", "AS", "KH", "7H" }), false };
            yield return new object[] { new Hand("Player1", new string[] { "2C", "2H", "4H", "KD", "6H" }), false };
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
            yield return new object[] { new Hand("Player1", new string[] { "AC", "AS", "AH", "AD", "10C" }), (int)FiveCardPokerEvaluator.HandRank.FourOfAKind + (int)Card.Values.Ace };
            yield return new object[] { new Hand("Player1", new string[] { "7C", "7S", "7H", "7D", "9C" }), (int)FiveCardPokerEvaluator.HandRank.FourOfAKind + (int)Card.Values.Seven };
        }

        [TestMethod]
        public void FindLesserRank()
        {
            var lesserHand = new Hand("higherHand", new string[] { "7C", "7S", "7H", "7D", "9C" });
            var higherHand = new Hand("lesserHand", new string[] { "AC", "AS", "AH", "AD", "10C" });

            int lesserRankScore = Eval.CalculateRankScore(lesserHand);
            int higherRankScore = Eval.CalculateRankScore(higherHand);
            Assert.IsTrue(lesserRankScore < higherRankScore);
        }
    }
}
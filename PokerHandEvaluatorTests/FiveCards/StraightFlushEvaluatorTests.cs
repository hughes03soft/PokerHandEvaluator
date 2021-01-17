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
    }
}
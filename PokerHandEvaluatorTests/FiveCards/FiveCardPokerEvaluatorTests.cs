using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokerHandEvaluator.FiveCards.Tests
{
    [TestClass()]
    public class FiveCardPokerEvaluatorTests
    {
        [DataTestMethod()]
        [DynamicData(nameof(GetCalculateRankScoreTestData), DynamicDataSourceType.Method)]
        public void GetWinnersTest(Dictionary<string, string[]> input, List<Hand> expectedWinners)
        {
            var fiveCardEval = new FiveCardPokerEvaluator();
            var winners = fiveCardEval.GetWinners(input);
            Assert.AreEqual(expectedWinners.Count, winners.Count);
            Assert.AreEqual(expectedWinners[0].Owner, winners[0].Owner);
            CollectionAssert.AreEqual(expectedWinners[0].RawCards, winners[0].RawCards);
        }
        public static IEnumerable<object[]> GetCalculateRankScoreTestData()
        {
            yield return new object[]
            {
                new Dictionary<string, string[]>()
                {
                    ["Joe"] =  new string [] { "3H", "6H", "8H", "JH", "KH" },
                    ["Jen"] =  new string [] { "3C", "3D", "3S", "8C", "10H" },
                    ["Bob"] =  new string [] { "2H", "5C", "7S", "10C", "AC" }
                },
                new List<Hand> ()
                {
                    new Hand("Joe", new string [] {"3H", "6H", "8H", "JH", "KH" })
                }
            };

            yield return new object[]
            {
                new Dictionary<string, string[]>()
                {
                    ["Joe"] =  new string [] { "3H", "4D", "9C", "9D", "QH" },
                    ["Jen"] =  new string [] { "5C", "7D", "9H", "9S", "QS" },
                    ["Bob"] =  new string [] { "2H", "2C", "5S", "10C", "AH" }
                },
                new List<Hand> ()
                {
                    new Hand("Jen", new string [] { "5C", "7D", "9H", "9S", "QS" })
                }
            };


        }
    }
}
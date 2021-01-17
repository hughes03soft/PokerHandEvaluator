using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandEvaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.Tests
{
    [TestClass()]
    public class CardTests
    {
        [DataTestMethod()]
        [DataRow("2C", Card.Suites.Club, Card.Values.Two)]
        [DataRow("AS", Card.Suites.Club, Card.Values.Two)]
        [DataRow("KH", Card.Suites.Club, Card.Values.Two)]
        [DataRow("10D", Card.Suites.Club, Card.Values.Two)]
        public void CardTest_ValidInput(string rawCard, Card.Suites expectedSuite, Card.Values expectedValue)
        {
            var card = new Card(rawCard);
            Assert.AreEqual(card.Suite, expectedSuite);
            Assert.AreEqual(card.Value, expectedValue);
        }

        [DataTestMethod()]
        [DataRow("2xC")]
        [DataRow("2")]
        [DataRow("")]
        public void CardTest_InvalidInput(string input)
        {
            Assert.ThrowsException <ArgumentException> (() => new Card(input));
        }
    }
}
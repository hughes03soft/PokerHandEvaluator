using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PokerHandEvaluator.Tests
{
    [TestClass()]
    public class CardTests
    {
        [DataTestMethod()]
        [DataRow("2C",  Card.Values.Two, Card.Suites.Club)]
        [DataRow("AS",  Card.Values.Ace, Card.Suites.Spade)]
        [DataRow("KH",  Card.Values.King, Card.Suites.Heart)]
        [DataRow("10D", Card.Values.Ten, Card.Suites.Diamond)]
        public void CardTest_ValidInput(string rawCard, Card.Values expectedValue, Card.Suites expectedSuite)
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
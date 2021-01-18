using System.Collections.Generic;
using System;

namespace PokerHandEvaluator
{
    public class Card
    {
        public const int SUITE_MASK = 0xF;

        public enum Suites
        {
            Club    = 1,
            Spade   = 1 << 1,
            Heart   = 1 << 2,
            Diamond = 1 << 3
        };

        public enum Values
        {
            Two     = 1 << 1,
            Three   = 1 << 2,
            Four    = 1 << 3,
            Five    = 1 << 4,
            Six     = 1 << 5,
            Seven   = 1 << 6,
            Eight   = 1 << 7,
            Nine    = 1 << 8,
            Ten     = 1 << 9,
            Jack    = 1 << 10,
            Queen   = 1 << 11,
            King    = 1 << 12,
            Ace     = (1 << 13) + 1 // +1 is for evaluating straight with 1 value
        };

        private static Dictionary<string, Suites> SuiteLookup = new Dictionary<string, Suites>()
        {
            { "C", Suites.Club},
            { "S", Suites.Spade},
            { "H", Suites.Heart},
            { "D", Suites.Diamond},
        };
        private static Dictionary<string, Values> ValueLookup = new Dictionary<string, Values>()
        {
            { "2", Values.Two},
            { "3", Values.Three},
            { "4", Values.Four},
            { "5", Values.Five},
            { "6", Values.Six},
            { "7", Values.Seven},
            { "8", Values.Eight},
            { "9", Values.Nine},
            { "10", Values.Ten},
            { "J", Values.Jack},
            { "Q", Values.Queen},
            { "K", Values.King},
            { "A", Values.Ace},
        };

        public Card(Values value, Suites suite)
        {
            Suite = suite;
            Value = value;
        }

        public Card(string card)
        {
            if (card.Length < 2)
                throw new ArgumentException();

            int valueLength = card.Length - 1;
            string valueKey = card.Substring(0, valueLength);

            if (ValueLookup.ContainsKey(valueKey))
                Value = ValueLookup[valueKey];
            else
                throw new ArgumentException();

            string suiteKey = card.Substring(card.Length - 1);
            if (SuiteLookup.ContainsKey(suiteKey))
                Suite = SuiteLookup[suiteKey];
            else
                throw new ArgumentException();
        }

        public Values Value { get; private set; }
        public Suites Suite { get; private set; }
    }

    public static class CardExt
    {
        private static Dictionary<Card.Values, int> ValueIntLookup = new Dictionary<Card.Values, int>()
        {
            {Card.Values.Two, 2},
            {Card.Values.Three, 3},
            {Card.Values.Four, 4},
            {Card.Values.Five, 5},
            {Card.Values.Six, 6},
            {Card.Values.Seven, 7},
            {Card.Values.Eight, 8},
            {Card.Values.Nine, 9},
            {Card.Values.Ten, 10},
            {Card.Values.Jack, 11},
            {Card.Values.Queen, 12},
            {Card.Values.King, 13},
            {Card.Values.Ace, 13},
        };

        public static int ToNumberValue(this Card.Values value)
        {
            int ret = -1;

            if (ValueIntLookup.ContainsKey(value))
                ret = ValueIntLookup[value];

            return ret;
        }
    }
}

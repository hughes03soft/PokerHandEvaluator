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
            Spade   = 1 << 2,
            Heart   = 1 << 3,
            Diamond = 1 << 4
        };
        public enum Values
        {
            Two     = 1 << 2,
            Three   = 1 << 3,
            Four    = 1 << 4,
            Five    = 1 << 5,
            Six     = 1 << 6,
            Seven   = 1 << 7,
            Eight   = 1 << 8,
            Nine    = 1 << 9,
            Ten     = 1 << 10,
            Jack    = 1 << 11,
            Queen   = 1 << 12,
            King    = 1 << 13,
            Ace     = (1 << 14) + 1 // +1 is for evaluating straight with 1 value
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
}

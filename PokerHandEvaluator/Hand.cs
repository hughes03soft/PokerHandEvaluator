using System.Collections.Generic;

namespace PokerHandEvaluator
{
    public class Hand
    {
        private Dictionary<Card.Values, int> CardValueDuplicateCounter = new Dictionary<Card.Values, int>();

        public string Owner { get; private set; }
        public string[] RawCards { get; private set; }
        public string Description { get; set; }
        public int RankScore { get; set; }

        //for evalution purposes
        public int OredCardValues { get; private set; } = 0;
        public int AndedSuites { get; private set; } = 0xFFFF;
        public int MaxDuplicateCount { get; private set; } = 0;
        public Card.Values CardValueOfMaxDuplicateCount { get; private set; }
        public Card.Values HighestCardValue { get; private set; } = Card.Values.Two;

        public Hand(string owner, string[] cards)
        {
            Owner = owner;
            RawCards = cards;

            foreach (var card in cards)
            {
                Card newCard = new Card(card);

                OredCardValues |= (int)newCard.Value;
                AndedSuites &= (int)newCard.Suite;

                if (newCard.Value > HighestCardValue)
                    HighestCardValue = newCard.Value;

                int count = 0;
                if (CardValueDuplicateCounter.ContainsKey(newCard.Value))
                    count = CardValueDuplicateCounter[newCard.Value];
                
                CardValueDuplicateCounter[newCard.Value] = ++count;
                if (count > MaxDuplicateCount)
                {
                    MaxDuplicateCount = count;
                    CardValueOfMaxDuplicateCount = newCard.Value;
                }
                    
            }
        }

        public int CardValueCount(Card.Values value)
        {
            if (CardValueDuplicateCounter.ContainsKey(value))
                return CardValueDuplicateCounter[value];
            else
                return 0;
        }

        public List<Card.Values> UniqueCardValues
        {
            get
            {
                return new List<Card.Values>(CardValueDuplicateCounter.Keys); 
            }
        }
    }
}

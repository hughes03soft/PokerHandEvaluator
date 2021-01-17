using System.Collections.Generic;

namespace PokerHandEvaluator
{
    public class Hand
    {
        public string Owner { get; private set; }
        public string[] RawCards { get; private set; }
        public List<Card> Cards { get; private set; } = new List<Card>();
        public string Description { get; set; }
        public int RankScore { get; set; }

        public int OredCardValues { get; private set; } = 0;
        public int AndedSuites { get; private set; } = 0xFFFF;
        public Card.Values MaxCardValue { get; private set; } = Card.Values.Two;

        public Hand(string owner, string[] cards)
        {
            Owner = owner;
            RawCards = cards;

            foreach (var card in cards)
            {
                Card newCard = new Card(card);
                Cards.Add(newCard);

                OredCardValues |= (int)newCard.Value;
                AndedSuites &= (int)newCard.Suite;

                if (newCard.Value > MaxCardValue)
                    MaxCardValue = newCard.Value;
            }
        }
    }
}

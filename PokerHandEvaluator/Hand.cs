using System.Collections.Generic;

namespace PokerHandEvaluator
{
    class Hand
    {
        public string Owner { get; private set; }
        public string[] RawCards { get; private set; }
        public List<Card> Cards { get; private set; } = new List<Card>();
        public string Description { get; set; }
        public int RankScore { get; set; }

        public Hand(string owner, string[] cards)
        {
            Owner = owner;
            RawCards = cards;

            foreach (var card in cards)
            {
                Cards.Add(new Card(card));
            }
        }
    }
}

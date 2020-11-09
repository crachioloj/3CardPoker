using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeCardPoker
{
    public class Player
    {
        public int PlayerNumber { get; }
        public IEnumerable<Card> Cards { get; }
        public HandType HandType { get; }

        public Player(int number, IEnumerable<Card> cards)
        {
            if (cards.Count() != Rules.CardsPerHand)
            {
                throw new InvalidOperationException("Only three cards are allowed per player.");
            }
            PlayerNumber = number;
            Cards = cards;
            HandType = HandTypeCalculator.GetHandTypeFromCards(cards);
        }
    }
}

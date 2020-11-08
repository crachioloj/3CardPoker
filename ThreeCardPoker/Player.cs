using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker
{
    public class Player
    {
        public int PlayerNumber { get; }
        public IEnumerable<Card> Cards { get; }

        public Player(int number, IEnumerable<Card> cards)
        {
            if (cards.Count() != 3)
            {
                throw new InvalidOperationException("Only three cards are allowed per player.");
            }
            PlayerNumber = number;
            Cards = cards;
        }
    }
}

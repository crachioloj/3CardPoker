using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker
{
    public class Card
    {
        public RankType Rank { get; }
        public SuitType Suit { get; }

        public Card(RankType rank, SuitType suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Card c = (Card)obj;
                return (c.Rank == Rank) && (c.Suit == Suit);
            }
        }
    }
}

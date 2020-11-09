using System;

namespace ThreeCardPoker
{
    public class Card : IEquatable<Card>
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
                Card otherCard = (Card)obj;
                return (otherCard.Rank == Rank) && (otherCard.Suit == Suit);
            }
        }

        public bool Equals(Card other)
        {
            return other != null &&
                   Rank == other.Rank &&
                   Suit == other.Suit;
        }

        public override int GetHashCode()
        {
            int hashCode = 483265535;
            hashCode = hashCode * -1521134295 + Rank.GetHashCode();
            hashCode = hashCode * -1521134295 + Suit.GetHashCode();
            return hashCode;
        }
    }
}

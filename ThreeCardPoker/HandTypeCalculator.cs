using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker
{
    public class HandTypeCalculator
    {
        public static HandType GetHandTypeFromCards(IEnumerable<Card> cards)
        {
            bool isThreeOfAKind = false;
            bool isStraight = false;
            bool isFlush = false;
            bool isPair = false;

            var cardList = cards.OrderBy(c => c.Rank).ToList();
            if (cardList[0].Suit == cardList[1].Suit && cardList[1].Suit == cardList[2].Suit)
            {
                isFlush = true;
            }

            if (cardList[0].Rank == cardList[1].Rank && cardList[1].Rank == cardList[2].Rank)
            {
                isThreeOfAKind = true;
            }
            else if (cardList[0].Rank == cardList[1].Rank
                || cardList[1].Rank == cardList[2].Rank
                || cardList[0].Rank == cardList[2].Rank)
            {
                isPair = true;
            }
            else if ((cardList[0].Rank + 1) == cardList[1].Rank
                && (cardList[1].Rank + 1) == cardList[2].Rank)
            {
                isStraight = true;
            }

            if (isStraight && isFlush)
            {
                return HandType.StraightFlush;
            }

            if (isThreeOfAKind)
            {
                return HandType.ThreeOfAKind;
            }

            if (isStraight)
            {
                return HandType.Straight;
            }

            if (isFlush)
            {
                return HandType.Flush;
            }

            if (isPair)
            {
                return HandType.Pair;
            }

            return HandType.HighCard;
        }
    }
}

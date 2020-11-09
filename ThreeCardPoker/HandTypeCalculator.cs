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
            bool isStraightFlush = false;
            bool isThreeOfAKind = false;
            bool isStraight = false;
            bool isFlush = false;
            bool isPair = false;
            bool isHighCard = true;

            var cardList = cards.OrderBy(c => c.Rank).ToList();
            if (cardList[0].Suit == cardList[1].Suit && cardList[1].Suit == cardList[2].Suit)
            {
                isFlush = true;
                isHighCard = false;
            }

            if (cardList[0].Rank == cardList[1].Rank && cardList[1].Rank == cardList[2].Rank)
            {
                isThreeOfAKind = true;
                isHighCard = false;
            }
            else if (cardList[0].Rank == cardList[1].Rank
                || cardList[1].Rank == cardList[2].Rank
                || cardList[0].Rank == cardList[2].Rank)
            {
                isPair = true;
                isHighCard = false;
            }
            else if ((cardList[0].Rank + 1) == cardList[1].Rank
                && (cardList[1].Rank + 1) == cardList[2].Rank)
            {
                isStraight = true;
                isHighCard = false;
            }

            isStraightFlush = isStraight && isFlush;

            throw new NotImplementedException();
        }
    }
}

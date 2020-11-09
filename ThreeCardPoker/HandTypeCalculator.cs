using System.Collections.Generic;
using System.Linq;

namespace ThreeCardPoker
{
    public class HandTypeCalculator
    {
        public static RankType GetHighestRankFromCards(IEnumerable<Card> cards) => cards.Select(c => c.Rank).Max();

        public static HandType GetHandTypeFromCards(IEnumerable<Card> cards)
        {
            bool isThreeOfAKind = false;
            bool isStraight = false;
            bool isFlush = false;
            bool isPair = false;

            var cardList = cards.OrderBy(c => c.Rank).ToList();

            isFlush = IsFlush(cardList);

            if (IsThreeOfAKind(cardList))
            {
                isThreeOfAKind = true;
            }
            else if (IsPair(cardList))
            {
                isPair = true;
            }
            else if (IsStraight(cardList))
            {
                isStraight = true;
            }

            if (isStraight && isFlush) return HandType.StraightFlush; 

            if (isThreeOfAKind) return HandType.ThreeOfAKind;

            if (isStraight) return HandType.Straight;

            if (isFlush) return HandType.Flush;

            if (isPair) return HandType.Pair;

            return HandType.HighCard;
        }

        private static bool IsFlush(List<Card> cardList)
        {
            return cardList[0].Suit == cardList[1].Suit && cardList[1].Suit == cardList[2].Suit;
        }

        private static bool IsThreeOfAKind(List<Card> cardList)
        {
            return cardList[0].Rank == cardList[1].Rank && cardList[1].Rank == cardList[2].Rank;
        }

        private static bool IsPair(List<Card> cardList)
        {
            return cardList[0].Rank == cardList[1].Rank
                || cardList[1].Rank == cardList[2].Rank
                || cardList[0].Rank == cardList[2].Rank;
        }

        private static bool IsStraight(List<Card> cardList)
        {
            var rankList = cardList.Select(card => card.Rank).ToList();
            var altRankList = cardList.Select(GetAlternateRankFromCard).OrderBy(c => c).ToList();
            return IsStraight(rankList) || IsStraight(altRankList);

            bool IsStraight(List<RankType> ranklist)
            {
                return (ranklist[0] + 1) == ranklist[1] && (ranklist[1] + 1) == ranklist[2];
            }
        }

        private static RankType GetAlternateRankFromCard(Card card)
        {
            return card.Rank == RankType.Ace ? RankType.LowAce : card.Rank;
        }
    }
}

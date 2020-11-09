using System;

namespace ThreeCardPoker
{
    public class CardFactory
    {
        public static Card CreateCard(string values)
        {
            if (values.Length != 2)
            {
                throw new InvalidOperationException("A card requires exactly two characters");
            }

            values = values.ToLower();

            char rankChar = values[0];
            char suitChar = values[1];

            RankType cardRank = GetRankFromCharacter(rankChar);
            SuitType cardSuit = GetSuitFromCharacter(suitChar);

            return new Card(cardRank, cardSuit);
        }

        private static RankType GetRankFromCharacter(char rankChar)
        {
            if (int.TryParse(rankChar.ToString(), out int numValue))
            {
                if (numValue < 2 || numValue > 9)
                {
                    throw new InvalidOperationException($"{rankChar} is a numeric value, but does not represent a valid rank.");
                }

                return (RankType)numValue;
            }

            switch (rankChar)
            {
                case 't':
                    return RankType.Ten;
                case 'j':
                    return RankType.Jack;
                case 'q':
                    return RankType.Queen;
                case 'k':
                    return RankType.King;
                case 'a':
                    return RankType.Ace;
                default:
                    throw new InvalidOperationException($"{rankChar} does not represent a valid rank.");
            }
        }

        private static SuitType GetSuitFromCharacter(char suitChar)
        {
            switch(suitChar)
            {
                case 'h':
                    return SuitType.Hearts;
                case 'd':
                    return SuitType.Diamonds;
                case 's':
                    return SuitType.Spades;
                case 'c':
                    return SuitType.Clubs;
                default:
                    throw new InvalidOperationException($"{suitChar} does not represent a valid suit.");
            }
        }

    }
}

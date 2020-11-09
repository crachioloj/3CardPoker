using System;
using System.Collections.Generic;

namespace ThreeCardPoker
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(string[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != Rules.ValuesPerDataRow)
            {
                throw new InvalidOperationException("Incorrect number of values provided.");
            }

            if (!int.TryParse(values[0], out int playerNumber) || playerNumber < 0)
            {
                throw new InvalidOperationException("Invalid value provided for player number.");
            }

            var cards = new List<Card>();
            for (int i = 1; i < Rules.ValuesPerDataRow; i++)
            {
                string cardValue = values[i];
                var card = CardFactory.CreateCard(cardValue);
                cards.Add(card);
            }

            var player = new Player(playerNumber, cards);

            return player;
        }
    }
}

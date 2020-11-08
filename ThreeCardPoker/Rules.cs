using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker
{
    public class Rules
    {
        public int CardsPerPlayer { get; } = 3;
        public int PlayerCount { get; }

        public Rules(int cardsPerPlayer, int playerCount)
        {
            CardsPerPlayer = cardsPerPlayer;
            PlayerCount = playerCount;
        }
    }
}

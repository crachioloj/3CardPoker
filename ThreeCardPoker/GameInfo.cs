using System.Collections.Generic;

namespace ThreeCardPoker
{
    public class GameInfo
    {
        public int PlayerCount { get; }
        public IEnumerable<Player> Players { get; }

        public GameInfo(int playerCount, IEnumerable<Player> players)
        {
            PlayerCount = playerCount;
            Players = players;
        }
    }
}

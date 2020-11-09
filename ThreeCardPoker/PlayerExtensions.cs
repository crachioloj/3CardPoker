using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker
{
    public static class PlayerExtensions
    {

        public static IEnumerable<Player> GetHighestRankedPlayers(this IEnumerable<Player> players)
        {
            if (players.Count() > 1)
            {
                var highestRank = players.Select(p => p.HighestRank).Max();
                return players.Where(p => p.HighestRank == highestRank);
            }
            return players;
        }
    }
}

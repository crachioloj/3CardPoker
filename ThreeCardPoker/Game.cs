using System.Collections.Generic;
using System.Linq;

namespace ThreeCardPoker
{
    public class Game
    {
        private readonly IEnumerable<Player> _Players;
        private readonly GameInfo _GameInfo;

        public Game(GameInfo gameInfo)
        {
            _GameInfo = gameInfo;
            _Players = _GameInfo.Players;
        }

        public string DetermineWinner()
        {
            var highestHand = _Players.Select(p => p.HandType).Max();
            var winningPlayerNumbers = _Players.Where(p => p.HandType == highestHand)
                .GetHighestRankedPlayers()
                .Select(p => p.PlayerNumber)
                .OrderBy(n => n);

            return string.Join(" ", winningPlayerNumbers);
        }
    }
}

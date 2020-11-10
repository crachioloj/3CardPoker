using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ThreeCardPoker
{
    public static class PlayerExtensions
    {
        public static IEnumerable<Player> ResolveTie(this IEnumerable<Player> players, HandType hand)
        {
            if (players.Count() == 1) return players;

            if (hand == HandType.ThreeOfAKind)
            {
                return ResolveThreeOfAKind(players);
            }

            if (hand == HandType.Pair)
            {
                return ResolvePair(players);
            }

            return ResolveOtherHands(players);
        }

        private static IEnumerable<Player> ResolveOtherHands(IEnumerable<Player> players)
        {
            var winners = players;
            for (int i = 0; i < Rules.CardsPerHand; i++)
            {
                var highestRank = RankType.LowAce;
                var winnerList = new List<Player>();
                foreach (var player in players)
                {
                    var playerHighest = player.Cards.OrderByDescending(c => c.Rank).Skip(i).First().Rank;
                    if (playerHighest > highestRank)
                    {
                        winnerList.Clear();
                        winnerList.Add(player);
                        highestRank = playerHighest;
                    }
                    else if (playerHighest == highestRank)
                    {
                        winnerList.Add(player);
                    }
                }

                if (winnerList.Count() == 1)
                {
                    winners = winnerList;
                    break;
                }
            }

            return winners;
        }

        private static IEnumerable<Player> ResolvePair(IEnumerable<Player> players)
        {
            var rankByPlayer = new Dictionary<Player, RankType>();
            var maxRank = RankType.LowAce;
            foreach (var player in players)
            {
                var pairRank = player.Cards
                    .GroupBy(c => c.Rank)
                    .Select(group => new { Rank = group.Key, Count = group.Count() })
                    .Where(g => g.Count == 2)
                    .Select(g => g.Rank)
                    .FirstOrDefault();

                rankByPlayer.Add(player, pairRank);
                if (pairRank > maxRank)
                {
                    maxRank = pairRank;
                }
            }

            var winners = rankByPlayer.Where(r => r.Value == maxRank).Select(r => r.Key);

            return winners;
        }

        private static IEnumerable<Player> ResolveThreeOfAKind(IEnumerable<Player> players)
        {
            var highestRank = players.Select(p => p.HighestRank).Max();
            var winners = players.Where(p => p.HighestRank == highestRank);

            return winners;
        }
    }
}

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

            //var remainingCardsByPlayer = new Dictionary<Player, List<Card>>();
            //foreach (var player in players)
            //{
            //    if (!remainingCardsByPlayer.ContainsKey(player))
            //    {
            //        remainingCardsByPlayer.Add(player, player.Cards.OrderByDescending(c => c.Rank).ToList());
            //    }
            //}

            //int remainingCards = 3;
            //bool winnerFound = false;
            //var highestRank = RankType.LowAce;
            //for (int i = 2; i >= 0; i--)
            //{
            //    foreach (var player in remainingCardsByPlayer.Keys)
            //    {
            //        if (remainingCardsByPlayer.TryGetValue(player, out List<Card> cards))
            //        {
            //            var rank = cards[i].Rank;
            //        }
            //    }
            //    remainingCards--;
            //}

            //// rank 1
            //if (winners.Count() > 1)
            //{
            //    var highestRank = winners.Select(p => p.HighestRank).Max();
            //    winners = players.Where(p => p.HighestRank == highestRank);
            //    // rank 2
            //    if (winners.Count() > 1)
            //    {
            //        foreach (var player in winners)
            //        {
            //            var cards = (player.Cards.Where(c => c.Rank != highestRank));
            //            //highestRank = 
            //        }
            //    }
            //}
            return players;
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

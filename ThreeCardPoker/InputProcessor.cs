using System;
using System.Linq;

namespace ThreeCardPoker
{
    public static class InputProcessor
    {
        public static GameInfo GetGameInfoFromStringInput(string input)
        {
            var rows = input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList()
                .Select(row => row.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

            var header = rows.First();

            if (header.Count() != 1 || !int.TryParse(header.First(), out int playerCount))
            {
                throw new InvalidOperationException("Invalid value provided for player count.");
            }

            var playerDataRows = rows.Skip(1);

            if (playerDataRows.Count() != playerCount)
            {
                throw new InvalidOperationException("Number of player data rows does not match expected player count.");
            }

            var cards = playerDataRows.Select(row => PlayerFactory.CreatePlayer(row));
            var gameInfo = new GameInfo(playerCount, cards);

            return gameInfo;
        }
    }
}

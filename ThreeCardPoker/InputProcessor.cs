using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker
{
    public static class InputProcessor
    {
        public static IEnumerable<IEnumerable<string>> ProcessStringInput(string input)
        {
            var rows = input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList()
                .Select(row => row.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

            var header = rows.First();
            int playerCount = header.Count() == 1 ? int.Parse(header.First()) : 0;

            if (playerCount < 1)
            {
                return null;
            }

            var cards = rows.Skip(1).Select(row => row);
            return null;
        }
    }
}

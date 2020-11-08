using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker
{
    public class Game
    {
        private readonly Rules _Rules;
        private readonly IEnumerable<Player> _Players;

        public Game(Rules rules, IEnumerable<Player> players)
        {
            _Rules = rules ?? throw new ArgumentNullException(nameof(rules));
            _Players = players;
        }
    }
}

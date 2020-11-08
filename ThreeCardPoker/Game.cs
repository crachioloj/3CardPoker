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
        private readonly int _PlayerCount;
        private readonly IEnumerable<Player> _Players;

        private readonly GameInfo _GameInfo;

        public Game(GameInfo gameInfo)
        {
            _GameInfo = gameInfo;
            _PlayerCount = _GameInfo.PlayerCount;
            _Players = _GameInfo.Players;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker
{
    [Flags]
    public enum HandType
    {
        HighCard = 0,
        Pair = 1,
        Flush = 2,
        Straight = 4,
        ThreeOfAKind = 8,
        StraightFlush = Flush | Straight,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker
{
    public static class Rules
    {
        public static readonly int CardsPerHand = 3;
        public static readonly int MinNumberSuit = 2;
        public static readonly int MaxNumberSuit = 9;
        public static readonly int ValuesPerDataRow = 4;
    }
}

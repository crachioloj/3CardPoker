using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeCardPoker;

using static ThreeCardPoker.InputProcessor;

namespace ThreeCardPoker.Test.InputProcessorTests
{
    [TestClass]
    public class WhenInputReceived
    {
        [TestMethod]
        public void ThenInputAccepted()
        {
            string input =
@"3     
0 2c As 4d   
1    Kd 5h 6c      
2 Jc Jd   9s  ";

            var info = InputProcessor.ProcessStringInput(input);
        }
    }
}

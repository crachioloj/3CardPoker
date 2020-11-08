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
        [DataRow(
@"a
0 2c As 4d
1    Kd 5h 6c
2 Jc Jd   9s  ")]
        [DataRow(
@"3 2c
0 2c As 4d
1 Kd 5h 6c
2 Jc Jd 9s")]
        [ExpectedException(typeof(InvalidOperationException), "Invalid value provided for player count.")]
        public void AndInputForPlayerCountIsInvalidThenExceptionIsThrown(string input)
        {
            var _ = InputProcessor.GetGameInfoFromStringInput(input);
        }

        [TestMethod]
        [DataRow(
@"1
0 2c As 4d
1    Kd 5h 6c
2 Jc Jd   9s  ")]
        [DataRow(
@"5
0 2c As 4d
1 Kd 5h 6c
2 Jc Jd 9s")]
        [DataRow(
@"4
0 2c As 4d")]
        [DataRow(
@"3")]
        [ExpectedException(typeof(InvalidOperationException), "Number of player data rows does not match expected player count.")]
        public void AndPlayerCountDoesNotMatchPlayerRowsThenExceptionIsThrown(string input)
        {
            var _ = InputProcessor.GetGameInfoFromStringInput(input);
        }
    }
}

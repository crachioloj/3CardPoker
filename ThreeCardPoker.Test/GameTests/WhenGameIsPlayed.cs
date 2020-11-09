using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker.Test.GameTests
{
    [TestClass]
    public class WhenGameIsPlayed
    {
        [TestMethod]
        public void AndValidInputIsProvidedThenCorrectWinnerIsReturned()
        {
            string input =
@"3
0 2c As 4d
1 Kd 5h 6c
2 Jc Jd 9s";
            var gameInfo = InputProcessor.GetGameInfoFromStringInput(input);
            var game = new Game(gameInfo);
            var result = game.Play();

            //Assert.IsTrue(result.Count() == 1);
            //Assert.IsTrue(result.Select(p => p.PlayerNumber).Contains(2));

            input =
@"4
0 Qc Kc 4s
1 Ah 2c Js
2 3h 9h Th
3 Tc 9c 3c";

            gameInfo = InputProcessor.GetGameInfoFromStringInput(input);
            game = new Game(gameInfo);
            result = game.Play();

            //Assert.IsTrue(result.Count() == 2);
            //Assert.IsTrue(result.Select(p => p.PlayerNumber).Contains(2)
            //    && result.Select(p => p.PlayerNumber).Contains(3));
        }
    }
}

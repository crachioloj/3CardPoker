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
        //        [DataRow(
        //@"3
        //0 2c As 4d
        //1 Kd 5h 6c
        //2 Jc Jd 9s", "2")]
        //        [DataRow(
        //@"4
        //0 Qc Kc 4s
        //1 Ah 2c Js
        //2 3h 9h Th
        //3 Tc 9c 3c", "2 3")]
        //        [DataRow(
        //@"4
        //0 5c 5s 5d
        //1 2d Ad 3d
        //2 Jc Jd 9s
        //3 Qc Kc Js", "1")]
        //        [DataRow(
        //@"2
        //0 Ah 5h 2h
        //1 Qd Jd 7d", "0")]
        //        [DataRow(
        //@"4
        //0 2c As 4d
        //1 Kd 5h 6c
        //2 Qc Jd 9s
        //3 Jd 5h As", "3")]
        //        [DataRow(
        //@"4
        //0 7c As Qd
        //1 Kd 5h 6c
        //2 Qc Jd 9s
        //3 Jd 5h As", "0")]
        //        [DataRow(
        //@"4
        //0 7c As Jd
        //1 Kd 5h 6c
        //2 Qc Jd 9s
        //3 Jd 5h As", "0")]
        //        [DataRow(
        //@"4
        //0 7c As Jd
        //1 Kd 5h 6c
        //2 Qc Jd 9s
        //3 Jd 7h As", "0 3")]
        //[DataRow(
        //@"3
        //0 7c As Jd
        //1 Ah 5h 2h
        //2 Qd Jd 7d", "1")]

        //Pair tiebreaker
        [DataRow(
        @"3
        0 5c 5s 4d
        1 Th Td Kc
        2 Qs Jd 7d", "1")]
        [DataRow(
        @"3
        0 2c 6s 5d
        1 Ts 5d Tc
        2 Ts 4d Td", "1 2")]

        //Three of a kind tiebreaker
        [DataRow(
        @"3
        0 5c 5s 5d
        1 4h 4d 4c
        2 Qs Jd 7d", "0")]
        [DataRow(
        @"3
        0 5c 5s 5d
        1 4h 4d 4c
        2 Qs Qd Qd", "2")]
        [DataRow(
        @"2
        0 5c 5s 5d
        1 5h 5d 5c", "0 1")]
        public void AndValidInputIsProvidedThenCorrectWinnerIsReturned(string input, string expectedOutput)
        {
            var (gameInfo, _) = InputProcessor.GetGameInfoFromStringInput(input);
            var game = new Game(gameInfo);
            string result = game.DetermineWinner();

            Assert.AreEqual(expectedOutput, result);
        }
    }
}

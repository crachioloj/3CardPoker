using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void AndInputForPlayerCountIsInvalidThenErrorIsReturned(string input)
        {
            var (info, error) = InputProcessor.GetGameInfoFromStringInput(input);
            Assert.IsNull(info);
            Assert.AreEqual("Invalid value provided for player count.", error);
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
        public void AndPlayerCountDoesNotMatchPlayerRowsThenErrorIsReturned(string input)
        {
            var (info, error) = InputProcessor.GetGameInfoFromStringInput(input);
            Assert.IsNull(info);
            Assert.AreEqual("Number of player data rows does not match expected player count.", error);
        }

        [TestMethod]
        [DataRow(
@"3
0 2c As 4d
1    Kd 5h 6c
2 Jc Jd   9s  ", 3)]
        [DataRow(
@"
2

    1  Kd 5h 6c                   

 2 Jc Jd   9s  ", 2)]
        public void AndInputIsValidWithExtraWhiteSpaceThenCorrectGameInfoCreated(string input, int playerCount)
        {
            var (info, _) = InputProcessor.GetGameInfoFromStringInput(input);
            Assert.AreEqual(playerCount, info.PlayerCount);
            foreach (var player in info.Players)
            {
                Assert.AreEqual(3, player.Cards.Count());
            }
        }

        [TestMethod]
        [DataRow(
@"3
0 2c As 4d
1 Kd 5h 6c
2 Jc Jd 9s", 3)]
        [DataRow(
@"4
0 Qc Kc 4s
1 Ah 2c Js
2 3h 9h Th
3 Tc 9c 3c", 4)]
        public void AndInputIsThenCorrectGameInfoCreated(string input, int playerCount)
        {
            var (info, _) = InputProcessor.GetGameInfoFromStringInput(input);
            Assert.AreEqual(playerCount, info.PlayerCount);
            foreach (var player in info.Players)
            {
                Assert.AreEqual(3, player.Cards.Count());
            }
        }
    }
}

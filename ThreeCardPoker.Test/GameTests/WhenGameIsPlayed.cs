using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThreeCardPoker.Test.GameTests
{
    [TestClass]
    public class WhenGameIsPlayed
    {
        [TestMethod]

        // Straight flush wins
        [DataRow(
@"4
0 5c 2s 5d
1 2d Ac 3d
2 4c Qd 9s
3 Jd Td Qd", "3")]

        // Three of a kind wins
        [DataRow(
@"4
0 Ac As Ad
1 2d 3c 7d
2 5c Td Qs
3 Jd 4d 4d", "0")]

        // Straight wins
        [DataRow(
@"4
0 5c 2s 5d
1 5d As 5d
2 Tc Qd Js
3 Qc 4c Js", "2")]

        // Straight (with Ace being lowest) wins
        [DataRow(
@"4
0 5c 2s 5d
1 2d Ad 3d
2 Jc Qd 9s
3 Qc 4c Js", "1")]

        // Pair wins
        [DataRow(
@"3
0 2c As 4d
1 Kd 5h 6c
2 Jc Jd 9s", "2")]

        // Flush, tie
        [DataRow(
@"4
0 Qc Kc 4s
1 Ah 2c Js
2 3h 9h Th
3 Tc 9c 3c", "2 3")]

        // Tiebreaker, flush, second highest suit needed
        [DataRow(
@"3
0 Ac Qc 4c
1 Kd 5h 6c
2 Ad Jd 9d", "0")]

        // Tiebreaker, flush, third suit needed
        [DataRow(
@"3
0 Ac Jc 4c
1 Kd 5h 6c
2 Ad Jd 9d", "2")]

        // Tiebreaker, flush
        [DataRow(
@"2
0 Ah 5h 2h
1 Qd Jd 7d", "0")]

        // Pair tiebreaker
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

        // Three of a kind tiebreaker
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

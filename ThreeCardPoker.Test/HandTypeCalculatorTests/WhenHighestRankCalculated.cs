using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker.Test.HandTypeCalculatorTests
{
    [TestClass]
    public class WhenHighestRankCalculated
    {
        [TestMethod]
        [DataRow(new string[] { "Ah", "5h", "2h" }, RankType.Ace)]
        [DataRow(new string[] { "Qd", "Jd", "7d" }, RankType.Queen)]
        [DataRow(new string[] { "2d", "2d", "2d" }, RankType.Two)]
        [DataRow(new string[] { "2s", "2h", "3s" }, RankType.Three)]
        [DataRow(new string[] { "Tc", "8d", "9d" }, RankType.Ten)]
        public void ThenCorrectValueReturned(string[] input, RankType expectedRank)
        {
            var cards = new List<Card>();
            for (int i = 0; i < input.Length; i++)
            {
                string cardValue = input[i];
                var card = CardFactory.CreateCard(cardValue);
                cards.Add(card);
            }

            var highestRank = HandTypeCalculator.GetHighestRankFromCards(cards);
            Assert.AreEqual(expectedRank, highestRank);
        }
    }
}

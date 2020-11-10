using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ThreeCardPoker.Test.CardFactoryTests
{
    [TestClass]
    public class WhenCreatingCard
    {
        [TestMethod]
        [DataRow("")]
        [DataRow("2")]
        [DataRow("2J3")]
        [ExpectedException(typeof(InvalidOperationException), "A card requires exactly two characters")]
        public void AndWrongNumberOfCharactersEnteredThenExceptionIsThrown(string value)
        {
            var _ = CardFactory.CreateCard(value);
        }

        [TestMethod]
        [DataRow("1h")]
        [DataRow("Pd")]
        [DataRow("bs")]
        [DataRow("0c")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AndInvalidRankValueEnteredThenExceptionIsThrown(string value)
        {
            var _ = CardFactory.CreateCard(value);
        }

        [TestMethod]
        [DataRow("aa")]
        [DataRow("2e")]
        [DataRow("K2")]
        [DataRow("Az")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AndInvalidSuitValueEnteredThenExceptionIsThrown(string value)
        {
            var _ = CardFactory.CreateCard(value);
        }

        [TestMethod]
        [DataRow("2c", RankType.Two, SuitType.Clubs)]
        [DataRow("3h", RankType.Three, SuitType.Hearts)]
        [DataRow("4d", RankType.Four, SuitType.Diamonds)]
        [DataRow("5s", RankType.Five, SuitType.Spades)]
        [DataRow("6c", RankType.Six, SuitType.Clubs)]
        [DataRow("7h", RankType.Seven, SuitType.Hearts)]
        [DataRow("8d", RankType.Eight, SuitType.Diamonds)]
        [DataRow("9s", RankType.Nine, SuitType.Spades)]
        [DataRow("Tc", RankType.Ten, SuitType.Clubs)]
        [DataRow("Jh", RankType.Jack, SuitType.Hearts)]
        [DataRow("Qd", RankType.Queen, SuitType.Diamonds)]
        [DataRow("Ks", RankType.King, SuitType.Spades)]
        [DataRow("AC", RankType.Ace, SuitType.Clubs)]
        public void AndInputIsValidThenCorrectRankAndSuitAreAssigned(
            string value, RankType expectedRank, SuitType expectedSuit)
        {
            var card = CardFactory.CreateCard(value);
            Assert.AreEqual(expectedRank, card.Rank);
            Assert.AreEqual(expectedSuit, card.Suit);
        }
    }
}

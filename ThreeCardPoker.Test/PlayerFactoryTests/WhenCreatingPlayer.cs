using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ThreeCardPoker.Test.PlayerFactoryTests
{
    [TestClass]
    public class WhenCreatingPlayer
    {
        [TestMethod]
        [DataRow(new string[] { "0", "2c", "As", "4d", "1" })]
        [DataRow(new string[] { "1", "2c", "As" })]
        [DataRow(new string[] { "2", "2c" })]
        [DataRow(new string[] { "3" })]
        [ExpectedException(typeof(InvalidOperationException), "Incorrect number of values per row provided.")]
        public void AndIncorrectNumberOfValuesProvidedThenExceptionIsThrown(string[] input)
        {
            var _ = PlayerFactory.CreatePlayer(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AndNullValueProvidedThenExceptionIsThrown()
        {
            var _ = PlayerFactory.CreatePlayer(null);
        }

        [TestMethod]
        [DataRow(new string[] { "a", "2c", "As", "4d"})]
        [DataRow(new string[] { "abc", "2c", "As", "4d" })]
        [DataRow(new string[] { "-1", "2c", "As", "4d" })]
        [DataRow(new string[] { "-500", "2c", "As", "4d" })]
        [ExpectedException(typeof(InvalidOperationException), "Invalid value provided for player number.")]
        public void AndInvalidValueProvidedForPlayerNumberThenExceptionIsThrown(string[] input)
        {
            var _ = PlayerFactory.CreatePlayer(input);
        }

        [TestMethod]
        public void AndInputIsValidThenPlayerIsCreatedCorrectly()
        {
            var player0 = PlayerFactory.CreatePlayer(new string[] { "0", "2c", "As", "4d" });
            Assert.AreEqual(0, player0.PlayerNumber);
            Assert.IsTrue(player0.Cards.Contains(new Card(RankType.Two, SuitType.Clubs)));
            Assert.IsTrue(player0.Cards.Contains(new Card(RankType.Ace, SuitType.Spades)));
            Assert.IsTrue(player0.Cards.Contains(new Card(RankType.Four, SuitType.Diamonds)));
            Assert.AreEqual(HandType.HighCard, player0.HandType);

            var player1 = PlayerFactory.CreatePlayer(new string[] { "1", "Kd", "5h", "6c" });
            Assert.AreEqual(1, player1.PlayerNumber);
            Assert.IsTrue(player1.Cards.Contains(new Card(RankType.King, SuitType.Diamonds)));
            Assert.IsTrue(player1.Cards.Contains(new Card(RankType.Five, SuitType.Hearts)));
            Assert.IsTrue(player1.Cards.Contains(new Card(RankType.Six, SuitType.Clubs)));
            Assert.AreEqual(HandType.HighCard, player1.HandType);

            var player2 = PlayerFactory.CreatePlayer(new string[] { "2", "Jc", "Jd", "9s" });
            Assert.AreEqual(2, player2.PlayerNumber);
            Assert.IsTrue(player2.Cards.Contains(new Card(RankType.Jack, SuitType.Clubs)));
            Assert.IsTrue(player2.Cards.Contains(new Card(RankType.Jack, SuitType.Diamonds)));
            Assert.IsTrue(player2.Cards.Contains(new Card(RankType.Nine, SuitType.Spades)));
            Assert.AreEqual(HandType.Pair, player2.HandType);

            player0 = PlayerFactory.CreatePlayer(new string[] { "0", "Qc", "Kc", "4s" });
            Assert.AreEqual(0, player0.PlayerNumber);
            Assert.IsTrue(player0.Cards.Contains(new Card(RankType.Queen, SuitType.Clubs)));
            Assert.IsTrue(player0.Cards.Contains(new Card(RankType.King, SuitType.Clubs)));
            Assert.IsTrue(player0.Cards.Contains(new Card(RankType.Four, SuitType.Spades)));
            Assert.AreEqual(HandType.HighCard, player0.HandType);

            player1 = PlayerFactory.CreatePlayer(new string[] { "1", "Ah", "2c", "Js" });
            Assert.AreEqual(1, player1.PlayerNumber);
            Assert.IsTrue(player1.Cards.Contains(new Card(RankType.Ace, SuitType.Hearts)));
            Assert.IsTrue(player1.Cards.Contains(new Card(RankType.Two, SuitType.Clubs)));
            Assert.IsTrue(player1.Cards.Contains(new Card(RankType.Jack, SuitType.Spades)));
            Assert.AreEqual(HandType.HighCard, player1.HandType);

            player2 = PlayerFactory.CreatePlayer(new string[] { "2", "3h", "9h", "Th" });
            Assert.AreEqual(2, player2.PlayerNumber);
            Assert.IsTrue(player2.Cards.Contains(new Card(RankType.Three, SuitType.Hearts)));
            Assert.IsTrue(player2.Cards.Contains(new Card(RankType.Nine, SuitType.Hearts)));
            Assert.IsTrue(player2.Cards.Contains(new Card(RankType.Ten, SuitType.Hearts)));
            Assert.AreEqual(HandType.Flush, player2.HandType);

            var player3 = PlayerFactory.CreatePlayer(new string[] { "3", "Tc", "9c", "3c" });
            Assert.AreEqual(3, player3.PlayerNumber);
            Assert.IsTrue(player3.Cards.Contains(new Card(RankType.Ten, SuitType.Clubs)));
            Assert.IsTrue(player3.Cards.Contains(new Card(RankType.Nine, SuitType.Clubs)));
            Assert.IsTrue(player3.Cards.Contains(new Card(RankType.Three, SuitType.Clubs)));
            Assert.AreEqual(HandType.Flush, player3.HandType);
        }
    }
}

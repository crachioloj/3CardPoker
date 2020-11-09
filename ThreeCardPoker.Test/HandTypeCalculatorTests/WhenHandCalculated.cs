using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker.Test.HandTypeCalculatorTests
{
    [TestClass]
    public class WhenHandCalculated
    {
        [TestMethod]
        [DataRow(new string[] { "Ac", "2c", "3c" }, HandType.StraightFlush)]
        [DataRow(new string[] { "2c", "3c", "4c" }, HandType.StraightFlush)]
        [DataRow(new string[] { "5d", "6d", "7d" }, HandType.StraightFlush)]
        [DataRow(new string[] { "8h", "9h", "Th" }, HandType.StraightFlush)]
        [DataRow(new string[] { "9h", "Th", "Jh" }, HandType.StraightFlush)]
        [DataRow(new string[] { "Js", "Qs", "Ks" }, HandType.StraightFlush)]
        [DataRow(new string[] { "Qs", "Ks", "As" }, HandType.StraightFlush)]
                                
        [DataRow(new string[] { "Ac", "2d", "3s" }, HandType.Straight)]
        [DataRow(new string[] { "2c", "3d", "4s" }, HandType.Straight)]
        [DataRow(new string[] { "5c", "6d", "7s" }, HandType.Straight)]
        [DataRow(new string[] { "8c", "9d", "Ts" }, HandType.Straight)]
        [DataRow(new string[] { "9c", "Td", "Js" }, HandType.Straight)]
        [DataRow(new string[] { "Jc", "Qd", "Ks" }, HandType.Straight)]
        [DataRow(new string[] { "Qc", "Kd", "As" }, HandType.Straight)]
                                
        [DataRow(new string[] { "2c", "2d", "2s" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "3c", "3d", "3s" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "4c", "4d", "4s" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "5c", "5d", "5s" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "6c", "6d", "6s" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "7c", "7d", "7s" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "8c", "8d", "8s" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "9c", "9d", "9s" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "Tc", "Td", "Ts" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "Jc", "Jd", "Js" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "Qc", "Qd", "Qs" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "Kc", "Kd", "Ks" }, HandType.ThreeOfAKind)]
        [DataRow(new string[] { "Ac", "Ad", "As" }, HandType.ThreeOfAKind)]
                                
        [DataRow(new string[] { "Ac", "4c", "8c" }, HandType.Flush)]
        [DataRow(new string[] { "Kd", "Kd", "9d" }, HandType.Flush)]
        [DataRow(new string[] { "Qh", "Jh", "5h" }, HandType.Flush)]
        [DataRow(new string[] { "7s", "Ks", "Ts" }, HandType.Flush)]
                                
        [DataRow(new string[] { "4c", "4d", "8h" }, HandType.Pair)]
        [DataRow(new string[] { "Kc", "Kd", "9h" }, HandType.Pair)]
        [DataRow(new string[] { "5c", "Jd", "5h" }, HandType.Pair)]
        [DataRow(new string[] { "7c", "Ad", "Ah" }, HandType.Pair)]
                                
        [DataRow(new string[] { "4c", "Td", "8h" }, HandType.HighCard)]
        [DataRow(new string[] { "Kc", "Ad", "9h" }, HandType.HighCard)]
        [DataRow(new string[] { "5c", "Jd", "Th" }, HandType.HighCard)]
        [DataRow(new string[] { "7c", "2d", "Ah" }, HandType.HighCard)]
        public void ThenCorrectHandTypeReturned(string[] input, HandType expectedHandType)
        {
            var cards = new List<Card>();
            for (int i = 0; i < input.Length; i++)
            {
                string cardValue = input[i];
                var card = CardFactory.CreateCard(cardValue);
                cards.Add(card);
            }
            var handType = HandTypeCalculator.GetHandTypeFromCards(cards);
            Assert.AreEqual(expectedHandType, handType);
        }
    }
}

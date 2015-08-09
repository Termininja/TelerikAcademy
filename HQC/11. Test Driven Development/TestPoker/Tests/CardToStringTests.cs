namespace TestPoker
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class CardToStringTests
    {
        [TestMethod]
        public void ToStringOfAceClubs()
        {
            var card = new Card(CardFace.Ace, CardSuit.Clubs);
            var result = card.ToString();
            Assert.AreEqual("A♣", result);
        }

        [TestMethod]
        public void ToStringOfTwoDiamonds()
        {
            var card = new Card(CardFace.Two, CardSuit.Diamonds);
            var result = card.ToString();
            Assert.AreEqual("2♦", result);
        }

        [TestMethod]
        public void ToStringOfQueenHearts()
        {
            var card = new Card(CardFace.Queen, CardSuit.Hearts);
            var result = card.ToString();
            Assert.AreEqual("Q♥", result);
        }

        [TestMethod]
        public void ToStringOfNineSpades()
        {
            var card = new Card(CardFace.Nine, CardSuit.Spades);
            var result = card.ToString();
            Assert.AreEqual("9♠", result);
        }
    }
}

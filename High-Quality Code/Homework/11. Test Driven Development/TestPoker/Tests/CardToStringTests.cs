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
            Card card = new Card(CardFace.Ace, CardSuit.Clubs);
            string result = card.ToString();
            Assert.AreEqual("A♣", result);
        }

        [TestMethod]
        public void ToStringOfTwoDiamonds()
        {
            Card card = new Card(CardFace.Two, CardSuit.Diamonds);
            string result = card.ToString();
            Assert.AreEqual("2♦", result);
        }

        [TestMethod]
        public void ToStringOfQueenHearts()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Hearts);
            string result = card.ToString();
            Assert.AreEqual("Q♥", result);
        }

        [TestMethod]
        public void ToStringOfNineSpades()
        {
            Card card = new Card(CardFace.Nine, CardSuit.Spades);
            string result = card.ToString();
            Assert.AreEqual("9♠", result);
        }
    }
}

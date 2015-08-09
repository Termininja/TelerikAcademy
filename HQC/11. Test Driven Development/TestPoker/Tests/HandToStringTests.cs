namespace TestPoker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System.Collections.Generic;

    [TestClass]
    public class HandToStringTests
    {
        [TestMethod]
        public void ToStringWithNoCards()
        {
            var hand = new Hand(new List<ICard>());
            var result = hand.ToString();
            Assert.AreEqual(String.Empty, result);
        }

        [TestMethod]
        public void ToStringWithSevenDiamonds()
        {
            var hand = new Hand(new List<ICard>() { new Card(CardFace.Seven, CardSuit.Diamonds) });
            var result = hand.ToString();
            Assert.AreEqual("7♦", result);
        }

        [TestMethod]
        public void ToStringWithFourCards()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades)
            });
            var result = hand.ToString();
            Assert.AreEqual("7♣ J♦ 4♠ K♥ 3♠", result);
        }

        [TestMethod]
        public void ToStringWithTwoEqualCards()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            });
            var result = hand.ToString();
            Assert.AreEqual("6♥ 6♥", result);
        }
    }
}

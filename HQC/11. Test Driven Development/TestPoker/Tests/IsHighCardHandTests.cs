namespace TestPoker
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System.Collections.Generic;

    [TestClass]
    public class IsHighCardHandTests
    {
        [TestMethod]
        public void HighCardHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void NotHighCardHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades)
            });

            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsHighCard(hand));
        }
    }
}

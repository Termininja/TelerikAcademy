namespace TestPoker
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System.Collections.Generic;

    [TestClass]
    public class IsFullHouseHandTests
    {
        [TestMethod]
        public void FullHouseHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void NotFullHouseHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            });

            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFullHouse(hand));
        }
    }
}

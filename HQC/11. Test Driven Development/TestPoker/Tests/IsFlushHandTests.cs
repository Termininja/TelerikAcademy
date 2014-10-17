﻿
namespace TestPoker
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System.Collections.Generic;

    [TestClass]
    public class IsFlushHandTests
    {
        [TestMethod]
        public void FlushHand()
        {
            Hand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs)
            });

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void NotFlushHand()
        {
            Hand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs)
            });

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFlush(hand));
        }
    }
}
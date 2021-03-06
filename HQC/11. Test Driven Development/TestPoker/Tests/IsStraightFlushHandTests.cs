﻿namespace TestPoker
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System.Collections.Generic;

    [TestClass]
    public class IsStraightFlushHandTests
    {
        [TestMethod]
        public void StraightFlushHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void NotStraightFlushHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsStraightFlush(hand));
        }
    }
}

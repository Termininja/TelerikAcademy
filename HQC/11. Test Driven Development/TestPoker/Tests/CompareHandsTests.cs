﻿namespace TestPoker
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System.Collections.Generic;

    [TestClass]
    public class CompareHandsTests
    {
        [TestMethod]
        public void TwoEaqualHands()
        {
            var firstHand = new Hand(new List<ICard>() {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs)
            });

            var secondHand = new Hand(new List<ICard>() {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs)
            });

            var checker = new PokerHandsChecker();
            Assert.AreEqual(0, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void FirstHandIsPowerful()
        {
            var firstHand = new Hand(new List<ICard>() {
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            });

            var secondHand = new Hand(new List<ICard>() {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            });

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void SecondHandIsPowerful()
        {
            var firstHand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs)
            });

            var secondHand = new Hand(new List<ICard>() {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            var checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }
    }
}

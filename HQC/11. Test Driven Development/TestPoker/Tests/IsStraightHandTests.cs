namespace TestPoker
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System.Collections.Generic;

    [TestClass]
    public class IsStraightHandTests
    {
        [TestMethod]
        public void StraightHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void NotStraightHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            });

            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsStraight(hand));
        }
    }
}

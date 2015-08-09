namespace TestPoker
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System.Collections.Generic;

    [TestClass]
    public class IsThreeOfAKindHandTests
    {
        [TestMethod]
        public void ThreeOfAKindHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void NotThreeOfAKindHand()
        {
            var hand = new Hand(new List<ICard>() {
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            });

            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }
    }
}

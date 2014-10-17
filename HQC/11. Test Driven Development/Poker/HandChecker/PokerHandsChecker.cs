namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        /// <summary>
        /// Checks if the hand is valid.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns true if the hand is valid.</returns>
        public bool IsValidHand(IHand hand)
        {
            if (hand != null)
            {
                List<ICard> cards = (List<ICard>)hand.Cards;

                if (cards.Count == 5)
                {
                    cards = cards.OrderBy(m => m.Face).ToList();

                    for (int i = 1; i < cards.Count; i++)
                    {
                        if (cards[i].ToString() == cards[i - 1].ToString())
                        {
                            return false;
                        }
                    }

                    return true;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The cards in the hand has to be 5!");
                }
            }
            else
            {
                throw new ArgumentNullException("The hand cannot be null!");
            }
        }

        /// <summary>
        /// Checks if the hand is a straight flush.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns true if the hand is a straight flush.</returns>
        public bool IsStraightFlush(IHand hand)
        {
            List<ICard> cards = (List<ICard>)hand.Cards;
            cards = cards.OrderBy(m => m.Face).ToList();

            for (int i = 1; i < cards.Count; i++)
            {
                if (cards[i].Suit != cards[i - 1].Suit || cards[i].Face != cards[i - 1].Face + 1)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the hand is four of a kind.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns true if the hand is four of a kind.</returns>
        public bool IsFourOfAKind(IHand hand)
        {
            List<ICard> cards = (List<ICard>)hand.Cards;
            var grouped = cards.GroupBy(m => m.Face).Where(k => k.Count() == 4);
            bool result = (grouped.Count() == 1) ? true : false;

            return result;
        }

        /// <summary>
        /// Checks if the hand is a full house.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns true if the hand is a full house.</returns>
        public bool IsFullHouse(IHand hand)
        {
            bool result =
                (this.IsOnePair(hand) && this.IsThreeOfAKind(hand)) ?
                true : false;

            return result;
        }

        /// <summary>
        /// Checks if the hand is a flush.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns true if the hand is a flush.</returns>
        public bool IsFlush(IHand hand)
        {
            List<ICard> cards = (List<ICard>)hand.Cards;

            for (int i = 1; i < cards.Count; i++)
            {
                if (cards[i].Suit != cards[i - 1].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the hand is a straight.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns true if the hand is a straight.</returns>
        public bool IsStraight(IHand hand)
        {
            List<ICard> cards = (List<ICard>)hand.Cards;
            cards = cards.OrderBy(m => m.Face).ToList();

            for (int i = 1; i < cards.Count; i++)
            {
                if (cards[i].Face != cards[i - 1].Face + 1)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the hand is three of a kind.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns true if the hand is three of a kind.</returns>
        public bool IsThreeOfAKind(IHand hand)
        {
            List<ICard> cards = (List<ICard>)hand.Cards;
            var grouped = cards.GroupBy(m => m.Face).Where(k => k.Count() == 3);
            bool result = (grouped.Count() == 1) ? true : false;

            return result;
        }

        /// <summary>
        /// Checks if the hand is two pair.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns true if the hand is two pair.</returns>
        public bool IsTwoPair(IHand hand)
        {
            List<ICard> cards = (List<ICard>)hand.Cards;
            var grouped = cards.GroupBy(m => m.Face).Where(k => k.Count() == 2);
            bool result = (grouped.Count() == 2) ? true : false;

            return result;
        }

        /// <summary>
        /// Checks if the hand is one pair.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns true if the hand is one pair.</returns>
        public bool IsOnePair(IHand hand)
        {
            List<ICard> cards = (List<ICard>)hand.Cards;
            var grouped = cards.GroupBy(m => m.Face).Where(k => k.Count() == 2);
            bool result = (grouped.Count() == 1) ? true : false;

            return result;
        }

        /// <summary>
        /// Checks if the hand is high card.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns true if the hand is high card.</returns>
        public bool IsHighCard(IHand hand)
        {
            if (this.IsFourOfAKind(hand) || this.IsThreeOfAKind(hand) ||
                this.IsTwoPair(hand) || this.IsOnePair(hand) ||
                this.IsStraight(hand) || this.IsFlush(hand) ||
                this.IsStraightFlush(hand) ||
                this.IsFullHouse(hand))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Compares two hands by their power.
        /// </summary>
        /// <param name="firstHand">The first hand.</param>
        /// <param name="secondHand">The second hand.</param>
        /// <returns>Returns 0 if both hands have the same power; 1 if the first
        /// hand is more powerful than the second hand, and -1 if the second hand
        /// is more powerful than the first one.</returns>
        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            int firstHandPower = TakeHandPower(firstHand);
            int secondHandPower = TakeHandPower(secondHand);

            if (firstHandPower > secondHandPower)
            {
                return 1;
            }
            if (firstHandPower < secondHandPower)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Takes the strength of the hand.
        /// </summary>
        /// <param name="hand">The hand.</param>
        /// <returns>Returns the strength of the hand.</returns>
        private int TakeHandPower(IHand hand)
        {
            if (this.IsStraightFlush(hand))
            {
                return 9;
            }
            if (this.IsFourOfAKind(hand))
            {
                return 8;
            }
            if (this.IsFullHouse(hand))
            {
                return 7;
            }
            if (this.IsFlush(hand))
            {
                return 6;
            }
            if (this.IsStraight(hand))
            {
                return 5;
            }
            if (this.IsThreeOfAKind(hand))
            {
                return 4;
            }
            if (this.IsTwoPair(hand))
            {
                return 3;
            }
            if (this.IsOnePair(hand))
            {
                return 2;
            }
            if (this.IsHighCard(hand))
            {
                return 1;
            }

            return 0;
        }
    }
}

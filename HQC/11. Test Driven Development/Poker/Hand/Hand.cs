namespace Poker
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Hand with cards.
    /// </summary>
    public class Hand : IHand
    {
        /// <summary>
        /// List of cards.
        /// </summary>
        public IList<ICard> Cards { get; private set; }

        /// <summary>
        /// Initializes a new instance of class Hand.
        /// </summary>
        /// <param name="cards">The list of cards.</param>
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        /// <summary>
        /// Information about all cards in this hand.
        /// </summary>
        /// <returns>Returns all cards in the hand as a string.</returns>
        public override string ToString()
        {
            string result = (this.Cards.Count > 0) ? String.Join(" ", this.Cards) : String.Empty;

            return result;
        }
    }
}

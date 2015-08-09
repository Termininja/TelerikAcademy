namespace Poker
{
    using System;

    /// <summary>
    /// Card with face and suit.
    /// </summary>
    public class Card : ICard
    {
        /// <summary>
        /// The card face.
        /// </summary>
        public CardFace Face { get; private set; }

        /// <summary>
        /// The card suit.
        /// </summary>
        public CardSuit Suit { get; private set; }

        /// <summary>
        /// Initializes a new instance of class Card.
        /// </summary>
        /// <param name="face">The card face.</param>
        /// <param name="suit">The card suit.</param>
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        /// <summary>
        /// Take the card face and suit.
        /// </summary>
        /// <returns>Returns the card as a string.</returns>
        public override string ToString()
        {
            var result = String.Empty;

            switch (this.Face)
            {
                case CardFace.Two:
                case CardFace.Three:
                case CardFace.Four:
                case CardFace.Five:
                case CardFace.Six:
                case CardFace.Seven:
                case CardFace.Eight:
                case CardFace.Nine:
                case CardFace.Ten:
                    result += (int)this.Face;
                    break;
                case CardFace.Jack:
                    result += "J";
                    break;
                case CardFace.Queen:
                    result += "Q";
                    break;
                case CardFace.King:
                    result += "K";
                    break;
                case CardFace.Ace:
                    result += "A";
                    break;
                default: break;
            }

            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    result += "♣";
                    break;
                case CardSuit.Diamonds:
                    result += "♦";
                    break;
                case CardSuit.Hearts:
                    result += "♥";
                    break;
                case CardSuit.Spades:
                    result += "♠";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}

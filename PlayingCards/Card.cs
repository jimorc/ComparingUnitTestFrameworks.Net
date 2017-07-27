using System;

namespace PlayingCards
{
    public class CardSuit
    {
        public enum SuitNames
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }

        public CardSuit(SuitNames suit)
        {
            switch (suit)
            {
                case SuitNames.Clubs:
                case SuitNames.Diamonds:
                case SuitNames.Hearts:
                case SuitNames.Spades:
                    this.suit = suit;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("CardSuit constructor", "The suit value is not valid.");
            }
        }

        public override string ToString()
        {
            switch (Suit)
            {
                case SuitNames.Clubs:
                    return "♣";
                case SuitNames.Diamonds:
                    return "♦";
                case SuitNames.Hearts:
                    return "♥";
                case SuitNames.Spades:
                    return "♠";
                default:
                    // Invalid value which should not occur. Just return a space.
                    // Note that given the validation performed in the constructor,
                    // there should be no way to actually get here.
                    return " ";
            }
        }

        public SuitNames Suit => suit;

        private readonly SuitNames suit;
    }

}
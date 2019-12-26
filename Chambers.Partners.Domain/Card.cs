using Chambers.Partners.Domain.Enums;

namespace Chambers.Partners.Domain
{
    public sealed class Card
    {
        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public CardSuit Suit { get; }
        public CardValue Value { get; }
    }
}

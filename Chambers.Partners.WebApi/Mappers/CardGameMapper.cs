using System.Linq;
using Chambers.Partners.Domain.ExtensionMethods;
using Chambers.Partners.WebApi.Models;

namespace Chambers.Partners.WebApi.Mappers
{
    public class CardGameMapper : ICardGameMapper
    {
        public Card Map(Domain.Card card) {
            return new Card
            {
                Suit = card.Suit.ToString(),
                Value = card.Value.GetDescription()
            };
        }

        public CardGame Map(Domain.BlackJackGame game)
        {
            return new CardGame
            {
                GameId = game.Identity,
                PlayerName = game.Player.Name,
                Cards = game.PlayerHand.Select(Map).ToList(),
                Winner = game.Winner()
            };
        }
    }

    
}

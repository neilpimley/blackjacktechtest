using System.Linq;
using Chambers.Partners.WebApi.Models;

namespace Chambers.Partners.WebApi.Mappers
{
    public class PlayerHandMapper : IPlayerHandMapper
    {
        public Card Map(Domain.Card card) {
            return new Card
            {
                Suit = card.Suit.ToString(),
                Value = ((int)card.Value).ToString()
            };
        }

        public PlayerHand Map(Domain.BlackJackGame game)
        {
            return new PlayerHand
            {
                PlayerName = game.Player.Name,
                Cards = game.PlayerHand.Select(Map).ToList()
            };
        }
    }

    
}

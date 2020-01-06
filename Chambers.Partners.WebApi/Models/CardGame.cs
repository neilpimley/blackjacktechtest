using System.Collections.Generic;

namespace Chambers.Partners.WebApi.Models
{
    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
    }

    public class CardGame
    {
        public int GameId { get; set; }
        public string PlayerName { get; set; }
        public List<Card> Cards { get; set; }
        public string Winner { get; set; }
    }
}

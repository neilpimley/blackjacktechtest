using System.Collections.Generic;

namespace Chambers.Partners.WebApi.Models
{
    public class PlayerHand
    {
        public string PlayerName { get; set; }
        public List<Card> Cards { get; set; }        
    }

    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
    }
}

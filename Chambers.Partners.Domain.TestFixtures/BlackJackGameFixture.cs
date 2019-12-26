using Chambers.Partners.Domain.Enums;
using System.Collections.Generic;

namespace Chambers.Partners.Domain.TestFixtures
{
    public class BlackJackGameFixture
    {
        private int _identity = 1;
        private Dealer _dealer = DealerFixture.InMemory.Create();
        private Player _player = PlayerFixture.InMemory.Create();
        private List<Card> _deck =  new List<Card>
        {
            new Card(CardSuit.Heart, CardValue.Two),
            new Card(CardSuit.Heart, CardValue.Three),
            new Card(CardSuit.Heart, CardValue.Four),
            new Card(CardSuit.Heart, CardValue.Five),
            new Card(CardSuit.Heart, CardValue.Six),
        };

        public static BlackJackGameFixture InMemory => new BlackJackGameFixture();

        public BlackJackGameFixture WithIdentity(int identity)
        {
            _identity = identity;
            return this;
        }

        public BlackJackGameFixture WithDealer(Dealer dealer)
        {
            _dealer = dealer;
            return this;
        }

        public BlackJackGameFixture WithPlayer(Player player)
        {
            _player = player;
            return this;
        }

        public BlackJackGameFixture WithDeck(List<Card> deck)
        {
            _deck = deck;
            return this;
        }

        public BlackJackGame Create()
        {
            return new BlackJackGame(_identity, _dealer, _player, _deck);
        }
    }
}

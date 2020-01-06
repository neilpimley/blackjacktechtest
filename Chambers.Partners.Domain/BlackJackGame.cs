using Chambers.Partners.Domain.Enums;
using Chambers.Partners.Domain.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chambers.Partners.Domain
{
    public sealed class BlackJackGame : IBlackJackGame
    {
        private List<Card> _dealerHand = new List<Card>();
        private List<Card> _playerHand = new List<Card>();
        private List<Card> _deck;
        private readonly int _identity;
        private readonly Dealer _dealer;
        private readonly Player _player;
        private GameStatus _status = GameStatus.NotStarted;

        public BlackJackGame(
            int identity,
            Dealer dealer, 
            Player player,
            List<Card> deck
        )
        {
            _identity = identity;
            _dealer = dealer;
            _player = player;
            _deck = deck;

        }

        public int Identity { get => _identity; }

        public Dealer Dealer { get => _dealer;  }

        public Player Player { get => _player; }

        public IReadOnlyList<Card> DealerHand { get => _dealerHand.AsReadOnly(); }

        public IReadOnlyList<Card> PlayerHand { get => _playerHand.AsReadOnly(); }

        public IReadOnlyList<Card> Deck { get => _deck.AsReadOnly(); }

        public int PlayerScore { get => _playerHand.CardsScore();  }

        public int DealerScore { get => _dealerHand.CardsScore(); }


        public void DealCardToPlayer(int? noOfCards)
        {
            if (_status == GameStatus.Complete)
                throw new InvalidOperationException("The player has already chosen to stick and cannot be dealt any more cards");

            if (_playerHand.CardsScore() > 21)
                throw new InvalidOperationException("The player is already bust");

            for (var i = 0; i < (noOfCards ?? 1); i++)
            {
                dealCardToPlayer();
            }

            _status = GameStatus.InProgress;
        }

        public void Stick()
        {
            if (_status == GameStatus.Complete)
                throw new InvalidOperationException("The player has already chosen to stick");

            _status = GameStatus.Complete;

            while (_dealerHand.CardsScore() < 17)
            {
                DealCardToDealer();
            }
        }

        public string Winner()
        {
            if (_status == GameStatus.Complete)
            {
                return _playerHand.CardsScore() > _dealerHand.CardsScore() ? _player.Name : _dealer.Name;
            }
            return _playerHand.CardsScore() > 21 ? _dealer.Name : string.Empty;
        }


        private void dealCardToPlayer()
        {
            var cardToDeal = _deck.First();
            _playerHand.Add(cardToDeal);
            _deck.Remove(cardToDeal);
        }

        private void DealCardToDealer()
        {
            var cardToDeal = _deck.First();
            _dealerHand.Add(cardToDeal);
            _deck.Remove(cardToDeal);
        }

    }
}

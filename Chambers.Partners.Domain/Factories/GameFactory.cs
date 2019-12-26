using Chambers.Partners.Domain.ExtensionMethods;
using Chambers.Partners.Domain.Providers;
using Chambers.Partners.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Factories
{
    public interface IGameFactory
    {
        BlackJackGame CreateBlackJackGame(int playerId);
        //PokerCardGame Create<PokerCardGame>(Guid playerId);
    }

    public class GameFactory
    {
        private ICardService _cardService;
        private IGameService _gameService;
        private IDealerProvider _dealerProvider;
        
        public GameFactory(
            ICardService cardService,
            IGameService gameService,
            IDealerProvider dealerProvider
        )
        {
            _cardService = cardService;
            _gameService = gameService;
            _dealerProvider = dealerProvider;
        }

        public async Task<BlackJackGame> CreateBlackJackGame(Guid playerId)
        {
            var players = new List<Player>();
            var dealer = (await _dealerProvider.GetAllAsync()).First();
            var deck = _cardService.GetDeck();
            deck.ShuffleCards();

            var gameId = await _gameService.GetNextGameId();

            return new BlackJackGame(gameId, dealer, players.First(), deck.ToList());
        }
    }
}

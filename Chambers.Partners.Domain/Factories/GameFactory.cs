using Chambers.Partners.Domain.ExtensionMethods;
using Chambers.Partners.Domain.Providers;
using Chambers.Partners.Domain.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Factories
{
    public class GameFactory : IGameFactory
    {
        private ICardService _cardService;
        private IGameService _gameService;
        private IDealerProvider _dealerProvider;
        private IPlayerProvider _playerProvider;

        public GameFactory(
            ICardService cardService,
            IGameService gameService,
            IDealerProvider dealerProvider,
            IPlayerProvider playerProvider
        )
        {
            _cardService = cardService;
            _gameService = gameService;
            _dealerProvider = dealerProvider;
            _playerProvider = playerProvider;
        }

        public async Task<BlackJackGame> CreateBlackJackGame(int playerId)
        {
            var player = await _playerProvider.GetAsync(playerId);
            if (player == null)
                throw new UnauthorizedAccessException("The player does not exist");

            var dealer = (await _dealerProvider.GetAllAsync()).First();
            var deck = _cardService.GetDeck();
            deck.ShuffleCards();

            var gameId = await _gameService.GetNextGameId();

            return new BlackJackGame(gameId, dealer, player, deck.ToList());
        }
    }
}

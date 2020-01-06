using Chambers.Partners.Domain.Factories;
using Chambers.Partners.Domain.Providers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Services
{
    
    public class GameService : IGameService
    {
        private IGameFactory _factory;
        private ICardGameProvider _provider;

        public GameService(
            IGameFactory factory,
            ICardGameProvider provider
            )
        {
            _factory = factory;
            _provider = provider;
        }

        public async Task<int> GetNextGameId()
        {
            return await _provider.GetNextGameIdentityAsync();
        }

        public async Task<BlackJackGame> StartBlackJack(int playerId)
        {
            var game = await _factory.CreateBlackJackGame(playerId);
            game.DealCardToPlayer(2);

            await _provider.InsertOrUpdateAsync(game);

            return game;
        }

        public async Task<BlackJackGame> Hit(int gameId, int playerId)
        {
            var game = await _provider.GetAsync(gameId);
            if (game == null)
                throw new UnauthorizedAccessException("The game does not exist");

            if (game.Player.Identity != playerId)
                throw new UnauthorizedAccessException("The player is not valid for this game");

            game.DealCardToPlayer(1);
            await _provider.InsertOrUpdateAsync(game);
            return game;
        }

        public async Task<BlackJackGame> Stick(int gameId, int playerId)
        {
            var game = await _provider.GetAsync(gameId);
            if (game == null)
                throw new UnauthorizedAccessException("The game does not exist");

            if (game.Player.Identity != playerId)
                throw new UnauthorizedAccessException("The player is not valid for this game");

            game.Stick();
            await _provider.InsertOrUpdateAsync(game);
            return game;
        }
    }
}

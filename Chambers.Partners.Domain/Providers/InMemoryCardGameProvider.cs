using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Providers
{
    public class InMemoryCardGameProvider : ICardGameProvider
    {
        private Dictionary<int, BlackJackGame> _games = new Dictionary<int, BlackJackGame>();

        public Task InsertOrUpdateAsync(BlackJackGame game)
        {
            _games[game.Identity] = game;
            return Task.CompletedTask;
        }

        public Task<int> GetNextGameIdentityAsync()
        {
            var identity = 1;
            if (_games.Any())
            {
                identity = _games.Values.Max(g => g.Identity) + 1;
            }
            return Task.FromResult(identity);
        }

        public Task<BlackJackGame> GetAsync(int gameId)
        {
            if (_games.ContainsKey(gameId))
            {
                return Task.FromResult(_games[gameId]);
            }
            throw new Exception("The game does not exist");
        }


    }
}

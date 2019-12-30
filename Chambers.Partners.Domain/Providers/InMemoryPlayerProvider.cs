using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Providers
{
    public class InMemoryPlayerProvider : IPlayerProvider
    {
        private Dictionary<int, Player> _players = new Dictionary<int, Player>()
        {
            { 1, new Player(1, "Mr Player") },
            { 2, new Player(2, "Mrs Player") },
        };

        public Task<Player> GetAsync(int playerId)
        {
            if (_players.ContainsKey(playerId))
            {
                return Task.FromResult(_players[playerId]);
            }
            throw new Exception("The dealer does not exist");
        }

        public Task<List<Player>> GetAllAsync()
        {
            return Task.FromResult(_players.Values.ToList());
        }
    }
}

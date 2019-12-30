using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Providers
{
    public interface IPlayerProvider
    {
        Task<List<Player>> GetAllAsync();
        Task<Player> GetAsync(int gameId);
    }


}

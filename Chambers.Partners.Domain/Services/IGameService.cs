using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Services
{
    public interface IGameService
    {
        Task<int> GetNextGameId();
        Task<IReadOnlyList<Card>> StartBlackJack(int playerId);
        Task<IReadOnlyList<Card>> Hit(int gameId, int playerId);
        Task<string> Stick(int gameId, int playerId);
    }

}

using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Services
{
    public interface IGameService
    {
        Task<int> GetNextGameId();
        Task<BlackJackGame> StartBlackJack(int playerId);
        Task<BlackJackGame> Hit(int gameId, int playerId);
        Task<BlackJackGame> Stick(int gameId, int playerId);
    }

}

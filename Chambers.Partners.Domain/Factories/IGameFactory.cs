using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Factories
{
    public interface IGameFactory
    {
        Task<BlackJackGame> CreateBlackJackGame(int playerId);
    }
}

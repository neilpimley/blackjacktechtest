using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Providers
{
    public interface ICardGameProvider
    {
        Task InsertOrUpdateAsync(BlackJackGame game);
        Task<int> GetNextGameIdentityAsync();
        Task<BlackJackGame> GetAsync(int gameId);
    }
}

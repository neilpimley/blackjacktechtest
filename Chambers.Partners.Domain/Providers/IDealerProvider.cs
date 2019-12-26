using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Providers
{
    public interface IDealerProvider
    {
        Task<List<Dealer>> GetAllAsync();
        Task<Dealer> GetAsync(int gameId);
    }


}

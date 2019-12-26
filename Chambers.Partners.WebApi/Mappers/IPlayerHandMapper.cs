using Chambers.Partners.WebApi.Models;

namespace Chambers.Partners.WebApi.Mappers
{
    public interface IPlayerHandMapper
    {
        Card Map(Domain.Card card);
        PlayerHand Map(Domain.BlackJackGame game);
    }
}

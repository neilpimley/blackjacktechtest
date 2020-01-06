using Chambers.Partners.WebApi.Models;

namespace Chambers.Partners.WebApi.Mappers
{
    public interface ICardGameMapper
    {
        Card Map(Domain.Card card);
        CardGame Map(Domain.BlackJackGame game);
    }
}

using System.Collections.Generic;

namespace Chambers.Partners.Domain.Services
{
    public interface ICardService
    {
        IList<Card> GetDeck();
    }
}

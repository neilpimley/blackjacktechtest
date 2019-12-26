using System;

namespace Chambers.Partners.Domain
{
    interface IBlackJackGame
    {
        void DealCardToPlayer(int? noOfCards);
        void Stick();
    }
}

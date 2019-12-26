using Chambers.Partners.Domain.Enums;

namespace Chambers.Partners.Domain
{
    public sealed class Dealer : Person
    {
        public Dealer(int identity, string name) : base(identity, name) { }

        public PlayerType playerType = PlayerType.Dealer;
    }
}

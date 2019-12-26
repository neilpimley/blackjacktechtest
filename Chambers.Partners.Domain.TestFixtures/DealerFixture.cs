using System;

namespace Chambers.Partners.Domain.TestFixtures
{
    public class DealerFixture
    {
        private int _identity = 1;
        private string _name = $"Dealer {Guid.NewGuid()}";

        public static DealerFixture InMemory => new DealerFixture();

        public DealerFixture WithIdentity(int identity)
        {
            _identity = identity;
            return this;
        }

        public DealerFixture WithName(string name)
        {
            _name = name;
            return this;
        }

        public Dealer Create()
        {
            return new Dealer(_identity, _name);
        }
    }
}

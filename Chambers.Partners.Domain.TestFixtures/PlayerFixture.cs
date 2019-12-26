using System;

namespace Chambers.Partners.Domain.TestFixtures
{
    public class PlayerFixture
    {
        private int _identity = 1;
        private string _name = $"Player {Guid.NewGuid()}";

        public static PlayerFixture InMemory => new PlayerFixture();

        public PlayerFixture WithIdentity(int identity)
        {
            _identity = identity;
            return this;
        }

        public PlayerFixture WithName(string name)
        {
            _name = name;
            return this;
        }

        public Player Create()
        {
            return new Player(_identity, _name);
        }
    }
}

using Chambers.Partners.Domain.Enums;
using System;

namespace Chambers.Partners.Domain
{
    public sealed class Player : Person
    {
        public Player(int identity, string name) : base(identity, name)
        {
            
        }
        public PlayerType PlayerType = PlayerType.Player;
    }
}

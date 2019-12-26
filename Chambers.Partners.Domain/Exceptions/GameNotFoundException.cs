using System;

namespace Chambers.Partners.Domain.Exceptions
{
    public class GameNotFoundException : Exception
    {
       public GameNotFoundException(string message) : base(message) { }
    }
}

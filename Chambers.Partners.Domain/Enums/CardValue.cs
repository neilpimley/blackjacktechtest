using System.ComponentModel;

namespace Chambers.Partners.Domain.Enums
{
    public enum CardValue
    {
        [Description("Ace")]
        Ace = 1,
        [Description("Two")]
        Two = 2,
        [Description("Three")]
        Three = 3,
        [Description("Four")]
        Four = 4,
        [Description("Five")]
        Five = 5,
        [Description("Six")]
        Six = 6,
        [Description("Seven")]
        Seven = 7,
        [Description("Eight")]
        Eight = 8,
        [Description("Nine")]
        Nine = 9,
        [Description("Ten")]
        Ten = 10,
        [Description("Jack")]
        Jack = 11,
        [Description("Queen")]
        Queen = 12,
        [Description("King")]
        King = 13
    }
}

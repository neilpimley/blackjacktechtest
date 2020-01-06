using System;
using System.ComponentModel;
using System.Linq;

namespace Chambers.Partners.Domain.ExtensionMethods
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var enumType = value.GetType();
            var enumMember = enumType.GetMember(value.ToString());
            var attributes = enumMember.First().GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length == 0)
            {
                throw new InvalidEnumArgumentException($"Enum value '{value}' does not have the DescriptionAttribute applied");
            }

            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
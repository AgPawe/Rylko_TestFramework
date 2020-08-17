using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace RyłkoWeb_TestFramework.Rylko_Pages.Enums
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum @enum)
        {
            return
                @enum
                    .GetType()
                    .GetMember(@enum.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? @enum.ToString();
        }
    }
}

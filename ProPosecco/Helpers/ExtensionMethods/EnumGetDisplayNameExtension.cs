using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ProProsecco.Helpers.ExtensionMethods
{
    public static class EnumGetDisplayNameExtension
    {
        public static string GetDisplayName(this Enum value)
        {
            return value.GetType()?
                        .GetMember(value.ToString())?
                        .First()?
                        .GetCustomAttribute<DisplayAttribute>()?
                        .Name;
        }
    }
}

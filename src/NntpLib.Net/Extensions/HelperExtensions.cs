using System;
using System.ComponentModel;
using System.Reflection;

namespace NntpLib.Net
{
    internal static class HelperExtensions
    {
        public static string GetDescription<T>(this T value) where T : struct
        {
            if (!typeof(T).IsEnum) throw new InvalidOperationException("Type must be an Enum.");

            var descriptionAttribute = typeof(T).GetField(value.ToString())
                .GetCustomAttribute<DescriptionAttribute>();

            return descriptionAttribute != null ? descriptionAttribute.Description : null;
        }

        public static string WithBrackets(this string value)
        {
            return string.Format("<{0}>", value.Trim('<', '>'));
        }
    }
}
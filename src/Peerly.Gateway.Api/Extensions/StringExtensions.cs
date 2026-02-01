using System;
using System.Linq;

namespace Peerly.Gateway.Api.Extensions;

public static class StringExtensions
{
    public static string ToCamelCase(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        var propertyNameSections = value
            .Split('.', StringSplitOptions.RemoveEmptyEntries)
            .Select(section => char.ToLower(section[0]) + section[1..]);

        return string.Join('.', propertyNameSections);
    }
}

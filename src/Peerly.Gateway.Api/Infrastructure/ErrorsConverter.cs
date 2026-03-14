using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Peerly.Gateway.Api.Extensions;

namespace Peerly.Gateway.Api.Infrastructure;

public static class ErrorsConverter
{
    private const string SummaryErrorPropertyName = "*";
    private static readonly Regex s_keywordExpression = new(@"\$\{(\w+)\}", RegexOptions.Compiled);

    public static IDictionary<string, string[]> ToApiErrorsDictionary(string? summaryError)
    {
        if (string.IsNullOrEmpty(summaryError))
            return new Dictionary<string, string[]>();

        return new Dictionary<string, string[]>
        {
            [SummaryErrorPropertyName] = new[] { summaryError }
        };
    }

    public static IDictionary<string, string[]> ToApiErrorsDictionary(IReadOnlyDictionary<string, string[]> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);

        return errors.ToDictionary(
            error => string.IsNullOrWhiteSpace(error.Key)
                ? SummaryErrorPropertyName
                : error.Key.ToCamelCase(),
            error => error.Value
                .Select(UpdateErrorMessageKeywords)
                .ToArray());
    }

    private static string UpdateErrorMessageKeywords(string errorMessage)
    {
        var matches = s_keywordExpression.Matches(errorMessage);
        if (matches.Count == 0)
            return errorMessage;

        var updatedErrorMessage = errorMessage;
        for (var i = 0; i < matches.Count; i++)
        {
            var keyword = matches[i].Groups[1].Value;
            updatedErrorMessage = updatedErrorMessage.Replace($"${{{keyword}}}", $"${{{keyword.ToCamelCase()}}}");
        }

        return updatedErrorMessage;
    }
}

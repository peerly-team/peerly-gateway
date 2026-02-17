using System;
using System.ComponentModel;
using AutoMapper.Extensions.EnumMapping;

namespace Peerly.Gateway.Api.Extensions;

internal static class EnumConfigurationExpressionExtensions
{
    public static IEnumConfigurationExpression<TSource, TDestination> ThrowFor<TSource, TDestination>(
        this IEnumConfigurationExpression<TSource, TDestination> enumConfigurationExpression,
        TSource source)
        where TSource : struct, Enum
        where TDestination : struct, Enum
    {
        return enumConfigurationExpression.MapException(
            source,
            () => new InvalidEnumArgumentException($"The value '{source}' of enum {typeof(TSource)} is not expected."));
    }
}

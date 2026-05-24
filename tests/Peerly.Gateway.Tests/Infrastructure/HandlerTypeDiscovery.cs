using System;
using System.Collections.Immutable;
using System.Linq;
using Peerly.Gateway.Api.Features;

namespace Peerly.Gateway.Tests.Infrastructure;

internal static class HandlerTypeDiscovery
{
    public sealed record HandlerMapping(
        Type HandlerType,
        Type RequestType,
        Type ResponseType,
        Type ProtoRequestType,
        Type ProtoResponseType);

    private static readonly Lazy<ImmutableArray<HandlerMapping>> s_lazy = new(Discover);

    public static ImmutableArray<HandlerMapping> All => s_lazy.Value;

    private static ImmutableArray<HandlerMapping> Discover()
    {
        var adapterOpenType = typeof(FeatureHandlerAdapter<,,,>);
        var apiAssembly = adapterOpenType.Assembly;

        return
        [
            ..apiAssembly.GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false })
                .Select(t => (Type: t, Base: FindAdapterBase(t, adapterOpenType)))
                .Where(x => x.Base is not null)
                .Select(
                    x =>
                    {
                        var args = x.Base!.GetGenericArguments();
                        return new HandlerMapping(x.Type, args[0], args[1], args[2], args[3]);
                    })
        ];
    }

    private static Type? FindAdapterBase(Type type, Type openGeneric)
    {
        var current = type.BaseType;
        while (current is not null)
        {
            if (current.IsGenericType && current.GetGenericTypeDefinition() == openGeneric)
                return current;
            current = current.BaseType;
        }

        return null;
    }
}

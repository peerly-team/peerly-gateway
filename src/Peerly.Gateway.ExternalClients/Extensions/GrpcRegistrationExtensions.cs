using System;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Peerly.Gateway.ExternalClients.Options;
using Peerly.Gateway.ExternalClients.ServiceVersions;

namespace Peerly.Gateway.ExternalClients.Extensions;

internal static class GrpcRegistrationExtensions
{
    public static IServiceCollection AddPeerlyCoreGrpcClient<TClient>(this IServiceCollection services)
        where TClient : ClientBase<TClient> =>
        services.AddScoped(sp => CreateClient<TClient>(sp, "core",
            sp.GetRequiredService<IOptionsSnapshot<PeerlyCoreGrpcClientOptions>>().Value.Target));

    public static IServiceCollection AddPeerlyAuthGrpcClient<TClient>(this IServiceCollection services)
        where TClient : ClientBase<TClient> =>
        services.AddScoped(sp => CreateClient<TClient>(sp, "auth",
            sp.GetRequiredService<IOptionsSnapshot<PeerlyAuthGrpcClientOptions>>().Value.Target));

    private static TClient CreateClient<TClient>(IServiceProvider sp, string serviceName, string defaultTarget)
        where TClient : ClientBase<TClient>
    {
        var resolver = sp.GetRequiredService<IServiceVersionResolver>();
        var pool = sp.GetRequiredService<IGrpcChannelPool>();
        var interceptor = sp.GetRequiredService<HeaderPropagationInterceptor>();
        var target = resolver.Resolve(serviceName, defaultTarget);
        var channel = pool.GetOrCreate(target);
        var invoker = channel.Intercept(interceptor);
        return (TClient)Activator.CreateInstance(typeof(TClient), invoker)!;
    }
}

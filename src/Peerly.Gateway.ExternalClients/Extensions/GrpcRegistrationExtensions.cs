using System;
using System.Net.Http;
using Grpc.Net.Client.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Peerly.Gateway.ExternalClients.Options;

namespace Peerly.Gateway.ExternalClients.Extensions;

public static class GrpcRegistrationExtensions
{
    public static IHttpClientBuilder AddPeerlyCoreGrpcClient<TClient>(this IServiceCollection services)
        where TClient : class
    {
        return services
            .AddGrpcClient<TClient>((sp, o) =>
            {
                var options = sp.GetRequiredService<IOptionsSnapshot<PeerlyCoreGrpcClientOptions>>().Value;
                o.Address = new Uri(options.Target);
            })
            .AddHttpMessageHandler<YcIamTokenHandler>()
            .ConfigurePrimaryHttpMessageHandler(BuildGrpcWebHandler);
    }

    public static IHttpClientBuilder AddPeerlyAuthGrpcClients<TClient>(this IServiceCollection services)
        where TClient : class
    {
        return services.AddGrpcClient<TClient>((sp, o) =>
                {
                    var options = sp.GetRequiredService<IOptionsSnapshot<PeerlyAuthGrpcClientOptions>>().Value;
                    o.Address = new Uri(options.Target);
                })
            .AddHttpMessageHandler<YcIamTokenHandler>()
            .ConfigurePrimaryHttpMessageHandler(BuildGrpcWebHandler);
    }

    private static HttpMessageHandler BuildGrpcWebHandler() =>
        new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler
        {
            // todo: отключить для нелокального окружения — небезопасно
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
        });
}

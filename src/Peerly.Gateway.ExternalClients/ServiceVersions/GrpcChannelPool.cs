using System.Collections.Concurrent;
using System.Net.Http;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace Peerly.Gateway.ExternalClients.ServiceVersions;

internal interface IGrpcChannelPool
{
    GrpcChannel GetOrCreate(string target);
}

internal sealed class GrpcChannelPool : IGrpcChannelPool
{
    private readonly ConcurrentDictionary<string, GrpcChannel> _channels = new();

    public GrpcChannel GetOrCreate(string target) =>
        _channels.GetOrAdd(target, CreateChannel);

    private static GrpcChannel CreateChannel(string target) =>
        GrpcChannel.ForAddress(target, new GrpcChannelOptions
        {
            HttpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
            }),
        });
}

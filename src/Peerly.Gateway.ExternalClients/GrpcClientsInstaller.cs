using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Peerly.Auth.V1;
using Peerly.Core.V1;
using Peerly.Gateway.ExternalClients.Options;
using Peerly.Gateway.Tools.Abstractions;

namespace Peerly.Gateway.ExternalClients;

[ExcludeFromCodeCoverage]
internal sealed class GrpcClientsInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services)
    {
        services
            .AddOptions<PeerlyAuthGrpcClientOptions>()
            .BindConfiguration(PeerlyAuthGrpcClientOptions.SectionName);
        services
            .AddOptions<PeerlyCoreGrpcClientOptions>()
            .BindConfiguration(PeerlyCoreGrpcClientOptions.SectionName);

        AddPeerlyCoreGrpcClients(services);
        AddPeerlyAuthGrpcClients(services);
    }

    private static void AddPeerlyCoreGrpcClients(IServiceCollection services)
    {
        services.AddGrpcClient<StorageService.StorageServiceClient>(
                (sp, o) =>
                {
                    var options = sp.GetRequiredService<IOptionsSnapshot<PeerlyCoreGrpcClientOptions>>().Value;

                    o.Address = new Uri(options.Target);
                })
            // todo: отключить для нелокального окружения - небезопасно
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });
    }

    private static void AddPeerlyAuthGrpcClients(IServiceCollection services)
    {
        services.AddGrpcClient<AuthService.AuthServiceClient>(
                (sp, o) =>
                {
                    var options = sp.GetRequiredService<IOptionsSnapshot<PeerlyAuthGrpcClientOptions>>().Value;

                    o.Address = new Uri(options.Target);
                })
            // todo: отключить для нелокального окружения - небезопасно
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });
    }
}

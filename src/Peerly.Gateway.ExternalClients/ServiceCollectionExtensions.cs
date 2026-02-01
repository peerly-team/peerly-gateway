using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Core.V1;

namespace Peerly.Gateway.ExternalClients;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGrpcClients(this IServiceCollection services)
    {
        services.AddPeerlyCoreGrpcClients();
        services.AddPeerlyAuthGrpcClients();

        return services;
    }

    private static void AddPeerlyCoreGrpcClients(this IServiceCollection services)
    {
        const string ServiceAddress = "https://localhost:5001";

        services.AddGrpcClient<StorageService.StorageServiceClient>(o => { o.Address = new Uri(ServiceAddress); })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });
    }

    private static void AddPeerlyAuthGrpcClients(this IServiceCollection services)
    {
        //const string ServiceName = "peerly-auth";

        //services.RegisterGrpcClient<InvoiceApi.InvoiceApiClient>(ServiceName);
    }
}

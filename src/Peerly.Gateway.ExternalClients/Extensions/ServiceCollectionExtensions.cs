using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Tools;

namespace Peerly.Gateway.ExternalClients.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureExternalClientsServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.InstallServicesFromExecutingAssembly(configuration);

        return services;
    }
}

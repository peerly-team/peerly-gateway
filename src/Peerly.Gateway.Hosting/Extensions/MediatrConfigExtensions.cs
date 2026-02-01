using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Api.Features.Storage.GenerateUploadUrl;

namespace Peerly.Gateway.Hosting.Extensions;

public static class MediatrConfigExtensions
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<GenerateUploadUrlHandler>();
        });
        return services;
    }
}

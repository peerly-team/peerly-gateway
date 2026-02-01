using AutoMapper.Extensions.EnumMapping;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Api.Features;

namespace Peerly.Gateway.Hosting.Extensions;

internal static class AutoMapperExtensions
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            config =>
            {
                config.EnableEnumMappingValidation();
                config.AddMaps(typeof(WellKnownTypesProfile).Assembly);
            });

        return services;
    }
}

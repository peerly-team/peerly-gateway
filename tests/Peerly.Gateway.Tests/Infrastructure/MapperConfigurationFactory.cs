using System;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Api.Features.Storage.GenerateUploadUrl;

namespace Peerly.Gateway.Tests.Infrastructure;

internal static class MapperConfigurationFactory
{
    private static readonly Lazy<IServiceProvider> s_lazyProvider = new(BuildProvider);

    public static IConfigurationProvider ConfigurationProvider => s_lazyProvider.Value.GetRequiredService<IConfigurationProvider>();
    public static IMapper Mapper => s_lazyProvider.Value.GetRequiredService<IMapper>();

    private static IServiceProvider BuildProvider()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddAutoMapper(
            config =>
            {
                config.EnableEnumMappingValidation();
                config.AddMaps(typeof(GenerateUploadUrlProfile).Assembly);
            });
        return services.BuildServiceProvider();
    }
}

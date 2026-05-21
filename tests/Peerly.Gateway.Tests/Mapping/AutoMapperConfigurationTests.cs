using Peerly.Gateway.Tests.Infrastructure;
using Xunit;

namespace Peerly.Gateway.Tests.Mapping;

public sealed class AutoMapperConfigurationTests
{
    [Fact]
    public void AutoMapper_ConfigurationIsValid()
    {
        var config = MapperConfigurationFactory.ConfigurationProvider;

        config.AssertConfigurationIsValid();
    }
}

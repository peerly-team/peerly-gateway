using System;
using Peerly.Gateway.Tests.Infrastructure;
using Xunit;

namespace Peerly.Gateway.Tests.Mapping;

public sealed class HandlerProfileCoverageTests
{
    public static TheoryData<string, Type, Type> ForwardMappings()
    {
        var data = new TheoryData<string, Type, Type>();
        foreach (var h in HandlerTypeDiscovery.All)
            data.Add(h.HandlerType.Name, h.RequestType, h.ProtoRequestType);
        return data;
    }

    public static TheoryData<string, Type, Type> ReverseMappings()
    {
        var data = new TheoryData<string, Type, Type>();
        foreach (var h in HandlerTypeDiscovery.All)
            data.Add(h.HandlerType.Name, h.ProtoResponseType, h.ResponseType);
        return data;
    }

    [Theory]
    [MemberData(nameof(ForwardMappings))]
    public void Handler_HasForwardMapping_Success(string handlerName, Type source, Type destination)
    {
        var mapper = MapperConfigurationFactory.Mapper;
        var instance = TestInstanceFactory.CreateInstance(source);

        var exception = Record.Exception(() => mapper.Map(instance, source, destination));

        Assert.True(exception is null,
            $"{handlerName}: forward mapping {source.Name} -> {destination.Name} failed: {exception?.Message}");
    }

    [Theory]
    [MemberData(nameof(ReverseMappings))]
    public void Handler_HasReverseMapping_Success(string handlerName, Type source, Type destination)
    {
        var mapper = MapperConfigurationFactory.Mapper;
        var instance = TestInstanceFactory.CreateInstance(source);

        var exception = Record.Exception(() => mapper.Map(instance, source, destination));

        Assert.True(exception is null,
            $"{handlerName}: reverse mapping {source.Name} -> {destination.Name} failed: {exception?.Message}");
    }
}

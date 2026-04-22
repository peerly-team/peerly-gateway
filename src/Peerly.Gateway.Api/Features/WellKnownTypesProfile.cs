using System;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace Peerly.Gateway.Api.Features;

public sealed class WellKnownTypesProfile : Profile
{
    public WellKnownTypesProfile()
    {
        CreateMap<DateTimeOffset, Timestamp>()
            .ConvertUsing(s => s.ToTimestamp());

        CreateMap<Timestamp, DateTimeOffset>()
            .ConvertUsing((timestamp, _) => timestamp?.ToDateTimeOffset() ?? throw new ArgumentNullException(nameof(timestamp)));
    }
}

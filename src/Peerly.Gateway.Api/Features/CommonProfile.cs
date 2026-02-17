using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Peerly.Gateway.Api.Extensions;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Common;
using AuthProto = Peerly.Auth.V1;

namespace Peerly.Gateway.Api.Features;

public sealed class CommonProfile : Profile
{
    public CommonProfile()
    {
        CreateMap<AuthProto.Role, Role>()
            .ConvertUsingEnumMapping(opt => opt.ThrowFor(AuthProto.Role.Unknown))
            .ReverseMap();

        CreateMap<AuthProto.ValidationError, ValidationError>();
        CreateMap<AuthProto.ValidationError.Types.ErrorMessagesCollection, string[]>()
            .ConstructUsing(messagesCollection => messagesCollection.ErrorMessage.ToArray());

        CreateMap<AuthProto.OtherError, OtherError>();
        CreateMap<AuthProto.OtherError.Types.ErrorType, ErrorType>()
            .ConvertUsingEnumMapping(opt => opt.ThrowFor(AuthProto.OtherError.Types.ErrorType.Unspecified));
    }
}

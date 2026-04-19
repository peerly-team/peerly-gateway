using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Peerly.Gateway.Api.Extensions;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Common;
using Peerly.Gateway.Api.Models.Course;
using Peerly.Gateway.Api.Models.Files;
using Peerly.Gateway.Api.Models.Group;
using Peerly.Gateway.Api.Models.Participants;
using AuthProto = Peerly.Auth.V1;
using CoreProto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features;

public sealed class CommonProfile : Profile
{
    public CommonProfile()
    {
        CreateMap<AuthProto.Role, Role>()
            .ConvertUsingEnumMapping(opt => opt.ThrowFor(AuthProto.Role.Unknown))
            .ReverseMap();
        CreateMap<AuthProto.Token, AuthToken>();

        CreateMap<AuthProto.ValidationError, ValidationError>();
        CreateMap<AuthProto.ValidationError.Types.ErrorMessagesCollection, string[]>()
            .ConstructUsing(messagesCollection => messagesCollection.ErrorMessage.ToArray());

        CreateMap<AuthProto.OtherError, OtherError>();
        CreateMap<AuthProto.OtherError.Types.ErrorType, ErrorType>()
            .ConvertUsingEnumMapping(opt => opt.ThrowFor(AuthProto.OtherError.Types.ErrorType.Unspecified));

        CreateMap<CoreProto.CourseStatus, CourseStatus>()
            .ConvertUsingEnumMapping(opt => opt.ThrowFor(CoreProto.CourseStatus.Unknown))
            .ReverseMap();
        CreateMap<PaginationInfo, CoreProto.PaginationInfo>();
        CreateMap<CoreProto.CourseInfo, CourseInfo>();

        CreateMap<CoreProto.ValidationError, ValidationError>();
        CreateMap<CoreProto.ValidationError.Types.ErrorMessagesCollection, string[]>()
            .ConstructUsing(messagesCollection => messagesCollection.ErrorMessage.ToArray());

        CreateMap<CoreProto.OtherError, OtherError>();
        CreateMap<CoreProto.OtherError.Types.ErrorType, ErrorType>()
            .ConvertUsingEnumMapping(opt => opt.ThrowFor(CoreProto.OtherError.Types.ErrorType.Unspecified));

        CreateMap<CoreProto.TeacherInfo, TeacherInfo>();
        CreateMap<CoreProto.StudentInfo, StudentInfo>();
        CreateMap<CoreProto.GroupInfo, GroupInfo>();
        CreateMap<CoreProto.File, File>();
    }
}

using System.Linq;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Peerly.Gateway.Api.Extensions;
using Peerly.Gateway.Api.Models.Auth;
using Peerly.Gateway.Api.Models.Common;
using Peerly.Gateway.Api.Models.Course;
using Peerly.Gateway.Api.Models.Files;
using Peerly.Gateway.Api.Models.Group;
using Peerly.Gateway.Api.Models.Homeworks;
using Peerly.Gateway.Api.Models.Participants;
using Peerly.Gateway.Api.Models.Rubrics;
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

        CreateMap<CoreProto.Role, Role>()
            .ConvertUsingEnumMapping(opt => opt.ThrowFor(CoreProto.Role.Unknown))
            .ReverseMap();

        CreateMap<CoreProto.CourseStatus, CourseStatus>()
            .ConvertUsingEnumMapping(opt => opt.ThrowFor(CoreProto.CourseStatus.Unknown))
            .ReverseMap();
        CreateMap<CoreProto.HomeworkStatus, HomeworkStatus>()
            .ConvertUsingEnumMapping(opt => opt.ThrowFor(CoreProto.HomeworkStatus.Unknown))
            .ReverseMap();
        CreateMap<SearchHomeworksFilter, CoreProto.SearchHomeworksFilter>();
        CreateMap<CoreProto.StudentHomeworkInfo, StudentHomeworkInfo>()
            .ForMember(dst => dst.RubricId,
                opt => opt.MapFrom(src => src.HasRubricId ? (long?)src.RubricId : null));
        CreateMap<CoreProto.TeacherHomeworkInfo, TeacherHomeworkInfo>()
            .ForMember(dst => dst.RubricId,
                opt => opt.MapFrom(src => src.HasRubricId ? (long?)src.RubricId : null));
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
        CreateMap<CoreProto.SubmittedReviewInfo, SubmittedReviewInfo>();
        CreateMap<CoreProto.SubmittedReviewScoreInfo, SubmittedReviewScoreInfo>()
            .ForMember(dst => dst.Comment,
                opt => opt.MapFrom(src => src.HasComment ? src.Comment : null));
        CreateMap<SubmittedReviewScoreInput, CoreProto.SubmittedReviewScoreInput>()
            .ForMember(dst => dst.Comment,
                opt => opt.Condition(src => src.Comment != null));

        CreateMap<CoreProto.RubricInfo, RubricInfo>();
        CreateMap<CoreProto.RubricCriterionInfo, RubricCriterionInfo>()
            .ForMember(dst => dst.Description,
                opt => opt.MapFrom(src => src.HasDescription ? src.Description : null));
        CreateMap<RubricCriterionInput, CoreProto.RubricCriterionInput>()
            .ForMember(dst => dst.Description,
                opt => opt.Condition(src => src.Description != null));
    }
}

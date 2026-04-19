using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.PostponeHomeworkDeadlines;

public sealed class PostponeHomeworkDeadlinesProfile : Profile
{
    public PostponeHomeworkDeadlinesProfile()
    {
        CreateMap<PostponeHomeworkDeadlinesCommand, V1PostponeHomeworkDeadlinesRequest>()
            .IncludeMembers(c => c.RequestBody);

        CreateMap<PostponeHomeworkDeadlinesRequestBody, V1PostponeHomeworkDeadlinesRequest>()
            .ForMember(dst => dst.Deadline, opt =>
            {
                opt.PreCondition(src => src.Deadline.HasValue);
                opt.MapFrom(src => src.Deadline!.Value.ToTimestamp());
            })
            .ForMember(dst => dst.ReviewDeadline, opt =>
            {
                opt.PreCondition(src => src.ReviewDeadline.HasValue);
                opt.MapFrom(src => src.ReviewDeadline!.Value.ToTimestamp());
            });

        CreateMap<V1PostponeHomeworkDeadlinesResponse, Result<EmptyResponse>>();
        CreateMap<V1PostponeHomeworkDeadlinesResponse.Types.Success, EmptyResponse>(MemberList.Source);
    }
}

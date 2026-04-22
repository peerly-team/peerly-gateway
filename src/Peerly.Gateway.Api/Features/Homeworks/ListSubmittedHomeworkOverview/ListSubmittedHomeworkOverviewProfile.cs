using AutoMapper;
using Peerly.Gateway.Api.Models.Homeworks;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Homeworks.ListSubmittedHomeworkOverview;

public sealed class ListSubmittedHomeworkOverviewProfile : Profile
{
    public ListSubmittedHomeworkOverviewProfile()
    {
        CreateMap<ListSubmittedHomeworkOverviewQuery, Proto.V1ListSubmittedHomeworkOverviewRequest>();
        CreateMap<Proto.V1ListSubmittedHomeworkOverviewResponse, ListSubmittedHomeworkOverviewQueryResponse>();
        CreateMap<Proto.V1ListSubmittedHomeworkOverviewResponse.Types.SubmittedHomeworkOverview, SubmittedHomeworkOverviewInfo>();
    }
}

using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.ListTeacherRubrics;

public sealed class ListTeacherRubricsHandler : FeatureHandlerAdapter<
    ListTeacherRubricsQuery, ListTeacherRubricsQueryResponse, V1ListTeacherRubricsRequest, V1ListTeacherRubricsResponse>
{
    public ListTeacherRubricsHandler(RubricService.RubricServiceClient client, IMapper mapper)
        : base(client.V1ListTeacherRubricsAsync, mapper)
    {
    }
}

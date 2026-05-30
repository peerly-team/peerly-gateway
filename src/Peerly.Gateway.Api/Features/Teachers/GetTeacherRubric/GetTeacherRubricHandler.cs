using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Teachers.GetTeacherRubric;

public sealed class GetTeacherRubricHandler : FeatureHandlerAdapter<
    GetTeacherRubricQuery, GetTeacherRubricQueryResponse, V1GetTeacherRubricRequest, V1GetTeacherRubricResponse>
{
    public GetTeacherRubricHandler(RubricService.RubricServiceClient client, IMapper mapper)
        : base(client.V1GetTeacherRubricAsync, mapper)
    {
    }
}

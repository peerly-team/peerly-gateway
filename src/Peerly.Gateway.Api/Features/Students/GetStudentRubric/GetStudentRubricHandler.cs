using AutoMapper;
using Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.GetStudentRubric;

public sealed class GetStudentRubricHandler : FeatureHandlerAdapter<
    GetStudentRubricQuery, GetStudentRubricQueryResponse, V1GetStudentRubricRequest, V1GetStudentRubricResponse>
{
    public GetStudentRubricHandler(RubricService.RubricServiceClient client, IMapper mapper)
        : base(client.V1GetStudentRubricAsync, mapper)
    {
    }
}

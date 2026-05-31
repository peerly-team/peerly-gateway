using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.BulkAddGroupStudents;

public sealed class BulkAddGroupStudentsHandler : FeatureHandlerAdapter<
    BulkAddGroupStudentsCommand, Result<BulkAddGroupStudentsCommandResponse>,
    V1BulkAddGroupStudentsRequest, V1BulkAddGroupStudentsResponse>
{
    public BulkAddGroupStudentsHandler(
        ParticipantService.ParticipantServiceClient client,
        IMapper mapper)
        : base(client.V1BulkAddGroupStudentsAsync, mapper)
    {
    }
}

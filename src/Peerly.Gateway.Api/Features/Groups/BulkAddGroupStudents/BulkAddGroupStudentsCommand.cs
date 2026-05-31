using System.Collections.Generic;
using MediatR;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Groups.BulkAddGroupStudents;

public sealed record BulkAddGroupStudentsCommand : IRequest<Result<BulkAddGroupStudentsCommandResponse>>
{
    public required long TeacherId { get; init; }
    public required long GroupId { get; init; }
    public required BulkAddGroupStudentsRequestBody RequestBody { get; init; }
}

public sealed record BulkAddGroupStudentsRequestBody
{
    public required IReadOnlyCollection<long> StudentIds { get; init; }
}

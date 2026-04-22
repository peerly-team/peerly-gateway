using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Submissions.DeleteSubmittedHomeworkFile;

public sealed class DeleteSubmittedHomeworkFileHandler :
    FeatureHandlerAdapter<DeleteSubmittedHomeworkFileCommand, Result<EmptyResponse>, V1DeleteSubmittedHomeworkFileRequest, V1DeleteSubmittedHomeworkFileResponse>
{
    public DeleteSubmittedHomeworkFileHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1DeleteSubmittedHomeworkFileAsync, mapper)
    {
    }
}

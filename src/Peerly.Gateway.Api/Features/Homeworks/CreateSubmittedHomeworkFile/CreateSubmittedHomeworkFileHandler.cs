using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CreateSubmittedHomeworkFile;

public sealed class CreateSubmittedHomeworkFileHandler : FeatureHandlerAdapter<
    CreateSubmittedHomeworkFileCommand, Result<CreateSubmittedHomeworkFileCommandResponse>, V1CreateSubmittedHomeworkFileRequest, V1CreateSubmittedHomeworkFileResponse>
{
    public CreateSubmittedHomeworkFileHandler(SubmissionService.SubmissionServiceClient client, IMapper mapper)
        : base(client.V1CreateSubmittedHomeworkFileAsync, mapper)
    {
    }
}

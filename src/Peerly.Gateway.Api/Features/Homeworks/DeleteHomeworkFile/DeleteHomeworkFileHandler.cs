using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.DeleteHomeworkFile;

public sealed class DeleteHomeworkFileHandler :
    FeatureHandlerAdapter<DeleteHomeworkFileCommand, Result<EmptyResponse>, V1DeleteHomeworkFileRequest, V1DeleteHomeworkFileResponse>
{
    public DeleteHomeworkFileHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1DeleteHomeworkFileAsync, mapper)
    {
    }
}

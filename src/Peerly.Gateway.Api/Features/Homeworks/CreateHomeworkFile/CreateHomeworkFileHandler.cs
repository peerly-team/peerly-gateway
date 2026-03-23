using AutoMapper;
using Peerly.Core.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Homeworks.CreateHomeworkFile;

public sealed class CreateHomeworkFileHandler : FeatureHandlerAdapter<
    CreateHomeworkFileCommand, Result<CreateHomeworkFileCommandResponse>, V1CreateHomeworkFileRequest, V1CreateHomeworkFileResponse>
{
    public CreateHomeworkFileHandler(HomeworkService.HomeworkServiceClient client, IMapper mapper)
        : base(client.V1CreateHomeworkFileAsync, mapper)
    {
    }
}

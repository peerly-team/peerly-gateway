using MediatR;

namespace Peerly.Gateway.Api.Features.Storage.GenerateUploadUrl;

public sealed record GenerateUploadUrlQuery : IRequest<GenerateUploadUrlQueryResponse>;

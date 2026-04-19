using AutoMapper;
using Peerly.Auth.V1;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Features.Auth.Refresh;

public sealed class RefreshHandler : FeatureHandlerAdapter<
    RefreshCommand, Result<RefreshCommandResponse>, V1RefreshRequest, V1RefreshResponse>
{
    public RefreshHandler(AuthService.AuthServiceClient client, IMapper mapper)
        : base(client.V1RefreshAsync, mapper)
    {
    }
}

using System;
using System.Threading;
using AutoMapper;
using Grpc.Core;
using Peerly.Auth.V1;

namespace Peerly.Gateway.Api.Features.AuthToken.GetJwsk;

public class GetJwksHandler : FeatureHandlerAdapter<
    GetJwksQuery, GetJwksQueryResponse, V1GetJwksRequest, V1GetJwksResponse>
{
    public GetJwksHandler(
        Func<V1GetJwksRequest, Metadata, DateTime?, CancellationToken, AsyncUnaryCall<V1GetJwksResponse>> grpcCall,
        IMapper mapper) : base(grpcCall, mapper)
    {
    }
}

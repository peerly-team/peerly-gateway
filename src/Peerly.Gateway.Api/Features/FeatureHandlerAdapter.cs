using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf;
using Grpc.Core;
using MediatR;

namespace Peerly.Gateway.Api.Features;

public abstract class FeatureHandlerAdapter<TRequest, TResponse, TProtoRequest, TProtoResponse>
    : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TProtoRequest : IMessage<TProtoRequest>
    where TProtoResponse : IMessage<TProtoResponse>
{
    private readonly Func<TProtoRequest, Metadata, DateTime?, CancellationToken, AsyncUnaryCall<TProtoResponse>> _grpcCall;

    private readonly IMapper _mapper;

    protected FeatureHandlerAdapter(
        Func<TProtoRequest, Metadata, DateTime?, CancellationToken, AsyncUnaryCall<TProtoResponse>> grpcCall,
        IMapper mapper)
    {
        _grpcCall = grpcCall;
        _mapper = mapper;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var grpcRequest = _mapper.Map<TRequest, TProtoRequest>(request);

        var grpcResponse = await _grpcCall(grpcRequest, null!, null, cancellationToken);

        return _mapper.Map<TProtoResponse, TResponse>(grpcResponse);
    }
}

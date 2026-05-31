using System.Linq;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Peerly.Gateway.ExternalClients.ServiceVersions;

internal sealed class HeaderPropagationInterceptor(IHttpContextAccessor httpContextAccessor) : Interceptor
{
    private const string MetadataKey = "x-peerly-service-versions";

    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        var ctx = TryAttachMetadata(context);
        return continuation(request, ctx);
    }

    public override TResponse BlockingUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        BlockingUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        var ctx = TryAttachMetadata(context);
        return continuation(request, ctx);
    }

    private ClientInterceptorContext<TRequest, TResponse> TryAttachMetadata<TRequest, TResponse>(
        ClientInterceptorContext<TRequest, TResponse> context)
        where TRequest : class
        where TResponse : class
    {
        var http = httpContextAccessor.HttpContext;
        var versions = http?.RequestServices.GetService<IServiceVersionContext>();
        if (versions is null || versions.Overrides.Count == 0)
            return context;

        var headerValue = string.Join(',', versions.Overrides.Select(kv => $"{kv.Key}={kv.Value}"));
        var headers = context.Options.Headers ?? new Metadata();
        headers.Add(MetadataKey, headerValue);

        var newOptions = context.Options.WithHeaders(headers);
        return new ClientInterceptorContext<TRequest, TResponse>(context.Method, context.Host, newOptions);
    }
}

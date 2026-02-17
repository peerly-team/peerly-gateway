using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Peerly.Gateway.Hosting.Middlewares;

internal sealed class ExceptionMiddleware : IMiddleware
{
    private readonly IProblemDetailsService _problemDetailsService;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(IProblemDetailsService problemDetailsService, ILogger<ExceptionMiddleware> logger)
    {
        _problemDetailsService = problemDetailsService;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "{ExceptionType} was processed by {MiddlewareName}: {ExceptionMessage}",
                exception.GetType().Name,
                nameof(ExceptionMiddleware),
                exception.Message);

            if (context.Response.HasStarted)
                throw;

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await _problemDetailsService.WriteAsync(new ProblemDetailsContext { HttpContext = context });
        }
    }
}

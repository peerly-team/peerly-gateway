using System;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Infrastructure.Filters;

internal sealed class RpcExceptionFilterAttribute : TypeFilterAttribute
{
    public RpcExceptionFilterAttribute()
        : base(typeof(RpcExceptionFilter))
    {
    }

    private sealed class RpcExceptionFilter : IExceptionFilter
    {
        private const string InvalidMeshVersionDetail = "Некорректное значение заголовка X-O3-Meshversion";

        private readonly ProblemDetailsFactory _problemDetailsFactory;
        private readonly ILogger<RpcExceptionFilter> _logger;

        public RpcExceptionFilter(ProblemDetailsFactory problemDetailsFactory, ILogger<RpcExceptionFilter> logger)
        {
            _problemDetailsFactory = problemDetailsFactory;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not RpcException rpcException)
                return;

            var actionResult = rpcException switch
            {
                { StatusCode: StatusCode.InvalidArgument } => FromInvalidArgument(context.HttpContext, rpcException),
                { StatusCode: StatusCode.FailedPrecondition } => FromFailedPrecondition(context.HttpContext, rpcException),
                { StatusCode: StatusCode.NotFound } => FromNotFound(context.HttpContext, rpcException),
                { StatusCode: StatusCode.Internal, Status.DebugException: ArgumentOutOfRangeException { ParamName: "meshVersion" } } =>
                    FromInvalidMeshVersion(context.HttpContext),
                _ => null
            };

            if (actionResult is null)
                return;

            LogRpcException(rpcException);

            context.Result = actionResult;
            context.ExceptionHandled = true;
        }

        private void LogRpcException(RpcException rpcException)
        {
            if (rpcException.StatusCode == StatusCode.Internal)
            {
                _logger.LogWarning(
                    rpcException,
                    "{ExceptionType} was handled by {FilterName}: {ExceptionMessage}",
                    rpcException.GetType().Name,
                    nameof(RpcExceptionFilter),
                    rpcException.Message);
            }
        }

        private ActionResult FromInvalidArgument(HttpContext httpContext, RpcException rpcException)
        {
            var validationProblemDetails = CreateValidationProblemDetails(
                httpContext,
                rpcException.Status.Detail,
                ValidationSource.FormatValidation);

            return new BadRequestObjectResult(validationProblemDetails);
        }

        private ActionResult FromFailedPrecondition(HttpContext httpContext, RpcException rpcException)
        {
            var validationProblemDetails = CreateValidationProblemDetails(
                httpContext,
                rpcException.Status.Detail,
                ValidationSource.BusinessValidation);

            return new BadRequestObjectResult(validationProblemDetails);
        }

        private ActionResult FromNotFound(HttpContext httpContext, RpcException rpcException)
        {
            var problemDetails = _problemDetailsFactory.CreateProblemDetails(
                httpContext,
                statusCode: StatusCodes.Status404NotFound,
                detail: rpcException.Status.Detail);

            return new ObjectResult(problemDetails);
        }

        private ActionResult FromInvalidMeshVersion(HttpContext httpContext)
        {
            var validationProblemDetails = CreateValidationProblemDetails(
                httpContext,
                InvalidMeshVersionDetail,
                ValidationSource.FormatValidation);

            return new BadRequestObjectResult(validationProblemDetails);
        }

        private ValidationProblemDetails CreateValidationProblemDetails(
            HttpContext httpContext,
            string detail,
            ValidationSource validationSource)
        {
            var validationProblemDetails = _problemDetailsFactory.CreateValidationProblemDetails(
                httpContext,
                new ModelStateDictionary(),
                statusCode: StatusCodes.Status400BadRequest);

            validationProblemDetails.Extensions["source"] = validationSource;

            var errors = ErrorsConverter.ToApiErrorsDictionary(detail);

            foreach (var (errorKey, errorValues) in errors)
            {
                validationProblemDetails.Errors.Add(errorKey, errorValues);
            }

            return validationProblemDetails;
        }
    }
}

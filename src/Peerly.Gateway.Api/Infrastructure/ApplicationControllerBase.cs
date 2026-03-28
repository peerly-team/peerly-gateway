using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Peerly.Gateway.Api.Extensions;
using Peerly.Gateway.Api.Infrastructure.Abstractions;
using Peerly.Gateway.Api.Infrastructure.Filters;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Infrastructure;

[Authorize]
[ModelStateFilter]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
public abstract class ApplicationControllerBase : ControllerBase
{
    protected ActionResult MatchResult(Result<EmptyResponse> result)
    {
        ArgumentNullException.ThrowIfNull(result, nameof(result));

        return result.Match(_ => NoContent(), BadRequest, OtherError);
    }

    protected ActionResult MatchResult<T>(Result<T> result, Func<T, ActionResult> success)
    {
        ArgumentNullException.ThrowIfNull(result, nameof(result));
        ArgumentNullException.ThrowIfNull(success, nameof(success));

        return result.Match(
            successResponse =>
            {
                WriteAuthCookies(successResponse);
                return success(successResponse);
            },
            BadRequest,
            OtherError);
    }

    protected ActionResult BadRequest(ValidationError validationError)
    {
        ArgumentNullException.ThrowIfNull(validationError);

        var propertyValidationErrors = ErrorsConverter.ToApiErrorsDictionary(validationError.Errors);

        var validationProblemDetails = new ValidationProblemDetails(propertyValidationErrors)
        {
            Status = StatusCodes.Status400BadRequest,
            Detail = validationError.ErrorDetail
        };

        foreach (var (key, value) in validationError.Extensions)
        {
            validationProblemDetails.Extensions[key.ToCamelCase()] = value;
        }

        validationProblemDetails.Extensions["source"] = ValidationSource.BusinessValidation;

        return ValidationProblem(validationProblemDetails);
    }

    protected ActionResult OtherError(OtherError otherError)
    {
        ArgumentNullException.ThrowIfNull(otherError);

        var statusCode = otherError.Type switch
        {
            ErrorType.PermissionDenied => StatusCodes.Status403Forbidden,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => throw new ArgumentException(
                $"{nameof(Models.Common.OtherError.Type)} property's value was {otherError.Type} which is out of expected range.",
                nameof(otherError))
        };

        return Problem(detail: otherError.Message, statusCode: statusCode);
    }

    protected bool TryGetRefreshToken(out string? refreshToken, out ActionResult? errorResult)
    {
        var authCookiesManager = HttpContext.RequestServices.GetRequiredService<IAuthCookiesManager>();
        if (authCookiesManager.TryGetRefreshToken(Request, out refreshToken))
        {
            errorResult = null;
            return true;
        }

        errorResult = CreateRefreshTokenRequiredResult();
        return false;
    }

    protected void ClearAuthCookies()
    {
        var authCookiesManager = HttpContext.RequestServices.GetRequiredService<IAuthCookiesManager>();
        authCookiesManager.ClearTokens(Response);
    }

    private void WriteAuthCookies<T>(T successResponse)
    {
        if (successResponse is not IAuthTokenResponse authTokenResponse)
            return;

        var authCookiesManager = HttpContext.RequestServices.GetRequiredService<IAuthCookiesManager>();
        authCookiesManager.WriteTokens(Response, authTokenResponse.Token);
    }

    private ActionResult CreateRefreshTokenRequiredResult()
    {
        const string ErrorMessage = "Refresh token cookie is required.";
        var errors = new Dictionary<string, string[]>
        {
            ["refreshToken"] = [ErrorMessage]
        };

        var validationProblemDetails = new ValidationProblemDetails(errors)
        {
            Status = StatusCodes.Status400BadRequest,
            Detail = ErrorMessage,
            Extensions =
            {
                ["source"] = ValidationSource.FormatValidation
            }
        };

        return ValidationProblem(validationProblemDetails);
    }
}

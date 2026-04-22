using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peerly.Gateway.Api.Extensions;
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

    protected ActionResult<T> MatchResult<T>(Result<T> result)
    {
        ArgumentNullException.ThrowIfNull(result, nameof(result));

        return result.Match(success => Ok(success), BadRequest, OtherError);
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
}

using System;
using Microsoft.AspNetCore.Mvc;

namespace Peerly.Gateway.Api.Models.Common;

public sealed record Result<TSuccessResponse>
{
    public required ResponseCase ResponseCase { get; init; }
    public required TSuccessResponse SuccessResponse { get; init; }
    public required ValidationError ValidationError { get; init; }
    public required OtherError OtherError { get; init; }

    public ActionResult Match(
        Func<TSuccessResponse, ActionResult> success,
        Func<ValidationError, ActionResult> validationError,
        Func<OtherError, ActionResult> otherError)
    {
        ArgumentNullException.ThrowIfNull(success);
        ArgumentNullException.ThrowIfNull(validationError);
        ArgumentNullException.ThrowIfNull(otherError);

        return ResponseCase switch
        {
            ResponseCase.SuccessResponse => success(SuccessResponse),
            ResponseCase.ValidationError => validationError(ValidationError),
            ResponseCase.OtherError => otherError(OtherError),
            ResponseCase.None => throw new InvalidOperationException(),
            _ => throw new InvalidOperationException()
        };
    }
}

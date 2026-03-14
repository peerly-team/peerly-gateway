namespace Peerly.Gateway.Api.Models.Common;

public enum ValidationSource
{
    None = 0,
    ModelState = 1,
    BusinessValidation = 2,
    FormatValidation = 3
}

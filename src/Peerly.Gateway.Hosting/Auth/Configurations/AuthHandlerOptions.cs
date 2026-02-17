using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;

namespace Peerly.Gateway.Hosting.Auth.Configurations;

public sealed class AuthHandlerOptions : AuthenticationSchemeOptions
{
    public const string SectionName = "AuthHandlerOptions";

    public string ValidIssuer { get; set; } = null!;
    public string ValidAudience { get; set; } = null!;
    public IReadOnlyCollection<string> ValidAlgorithms { get; set; } = [];
    public bool RequireKid { get; set; }
    public TimeSpan ClockSkew { get; set; }
}

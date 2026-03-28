using Microsoft.AspNetCore.Http;

namespace Peerly.Gateway.Hosting.Auth.Cookies;

public sealed class AuthCookieOptions
{
    public const string SectionName = "Cookies";

    public string AccessName { get; set; } = "access";
    public string RefreshName { get; set; } = "refresh";
    public string CsrfName { get; set; } = "csrf";
    public bool Secure { get; set; } = true;
    public SameSiteMode SameSite { get; set; } = SameSiteMode.Lax;
    public string RefreshPath { get; set; } = "/api/v1/sessions";
}

namespace Peerly.Gateway.Hosting.Auth.Configurations;

public sealed class AuthConfiguration
{
    public const string SectionName = "AuthConfiguration";
    public string ClientId { get; set; } = string.Empty;
}

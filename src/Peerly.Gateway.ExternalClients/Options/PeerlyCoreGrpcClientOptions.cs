namespace Peerly.Gateway.ExternalClients.Options;

internal sealed record PeerlyCoreGrpcClientOptions
{
    public const string SectionName = "PeerlyCoreGrpcClientOptions";

    public required string Target { get; init; } = null!;
    public required bool UseClientSideBalancing { get; init; }
}

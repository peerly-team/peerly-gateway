namespace Peerly.Gateway.ExternalClients.Options;

internal sealed class PeerlyAuthGrpcClientOptions
{
    public const string SectionName = "PeerlyAuthGrpcClientOptions";

    public required string Target { get; init; } = null!;
    public required bool UseClientSideBalancing { get; init; }
}

namespace Peerly.Gateway.Api.Models.Course;

public sealed record PaginationInfo
{
    public int Offset { get; init; }
    public int PageSize { get; init; }
}

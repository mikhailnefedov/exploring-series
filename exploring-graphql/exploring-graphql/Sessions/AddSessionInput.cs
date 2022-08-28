using exploring_graphql.Models;

namespace exploring_graphql.Sessions
{
    public record AddSessionInput(
        string Title,
        string? Abstract,
        [ID(nameof(Speaker))] IReadOnlyList<int> SpeakerIds);
}

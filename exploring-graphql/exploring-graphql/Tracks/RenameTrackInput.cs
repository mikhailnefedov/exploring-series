using exploring_graphql.Models;

namespace exploring_graphql.Tracks
{
    public record RenameTrackInput([ID(nameof(Track))] int id, string Name);
}

using exploring_graphql.Data;
using exploring_graphql.Extensions;
using exploring_graphql.Models;

namespace exploring_graphql.Tracks
{
    [ExtendObjectType("Mutation")]
    public class TrackMutations
    {
        [UseApplicationDbContext]
        public async Task<AddTrackPayload> AddTrackAsync(
            AddTrackInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var track = new Track { Name = input.Name };
            context.Tracks.Add(track);

            await context.SaveChangesAsync(cancellationToken);

            return new AddTrackPayload(track);
        }

        [UseApplicationDbContext]
        public async Task<RenameTrackPayload> RenameTrackAsync(
            RenameTrackInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            Track track = await context.Tracks.FindAsync(input.id);
            track.Name = input.Name;

            await context.SaveChangesAsync(cancellationToken);

            return new RenameTrackPayload(track);
        }
    }
}

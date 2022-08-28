using exploring_graphql.Data;
using exploring_graphql.DataLoader;
using exploring_graphql.Extensions;
using exploring_graphql.Models;
using Microsoft.EntityFrameworkCore;

namespace exploring_graphql.Tracks
{
    [ExtendObjectType("Query")]
    public class TrackQueries
    {
        [UseApplicationDbContext]
        public async Task<IEnumerable<Track>> GetTracksAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.Tracks.ToListAsync(cancellationToken);

        [UseApplicationDbContext]
        public Task<Track> GetTrackByNameAsync(
            string name,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            context.Tracks.FirstAsync(t => t.Name == name);

        [UseApplicationDbContext]
        public async Task<IEnumerable<Track>> GetTrackByNamesAsync(
            string[] names,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.Tracks.Where(t => names.Contains(t.Name)).ToListAsync();

        public Task<Track> GetTrackByIdAsync(
            [ID(nameof(Track))] int id,
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken) =>
            trackById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Track>> GetTracksByIdAsync(
            [ID(nameof(Track))] int[] ids,
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken) =>
            await trackById.LoadAsync(ids, cancellationToken);

    }
}

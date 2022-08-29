using exploring_graphql.Data;
using exploring_graphql.DataLoader;
using exploring_graphql.Extensions;
using exploring_graphql.Models;
using Microsoft.EntityFrameworkCore;

namespace exploring_graphql.Speakers
{
    [ExtendObjectType("Query")]
    public class SpeakerQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        public IQueryable<Speaker> GetSpeakers(
            [ScopedService] ApplicationDbContext context) =>
            context.Speakers.OrderBy(t => t.Name);

        public async Task<Speaker> GetSpeakerByIdAsync(
            [ID(nameof(Speaker))] int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            return await dataLoader.LoadAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Speaker>> GetSpeakersByIdAsync(
            [ID(nameof(Speaker))] int[] ids,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            return await dataLoader.LoadAsync(ids, cancellationToken);
        }
    }
}

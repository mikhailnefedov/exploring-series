using exploring_graphql.Data;
using exploring_graphql.DataLoader;
using exploring_graphql.Extensions;
using exploring_graphql.Models;
using exploring_graphql.Types;
using Microsoft.EntityFrameworkCore;

namespace exploring_graphql.Sessions
{
    [ExtendObjectType("Query")]
    public class SessionQueries
    {
        [UseApplicationDbContext]
        [UsePaging(typeof(NonNullType<SessionType>))]
        [UseFiltering(typeof(SessionFilterInputType))]
        [UseSorting]
        public IQueryable<Session> GetSessions(
            [ScopedService] ApplicationDbContext context) =>
            context.Sessions;

        public Task<Session> GetSessionByIdAsync(
            [ID(nameof(Session))] int id,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken) =>
            sessionById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Session>> GetSessionsByIdAsync(
            [ID(nameof(Session))] int[] ids,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken) =>
            await sessionById.LoadAsync(ids, cancellationToken);
    }
}


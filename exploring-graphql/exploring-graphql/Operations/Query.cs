using exploring_graphql.Data;
using exploring_graphql.Extensions;
using exploring_graphql.Models;
using Microsoft.EntityFrameworkCore;

namespace exploring_graphql.Operations
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context)
        {
            return context.Speakers.ToListAsync();
        }     
    }
}

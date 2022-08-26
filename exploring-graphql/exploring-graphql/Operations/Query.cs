﻿using exploring_graphql.Data;
using exploring_graphql.DataLoader;
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

        public Task<Speaker> GetSpeakerAsync(
            int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            return dataLoader.LoadAsync(id, cancellationToken);
        }
    }
}

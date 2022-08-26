using exploring_graphql.Data;
using exploring_graphql.Extensions;
using exploring_graphql.Models;

namespace exploring_graphql.Operations
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,
            [ScopedService] ApplicationDbContext context
            )
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }
    }
}

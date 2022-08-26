using exploring_graphql.Data;
using exploring_graphql.Models;

namespace exploring_graphql.Operations
{
    public class Query
    {
        public IQueryable<Speaker> GetSpeakers([Service] DataContext context)
        {
            return context.Speakers;
        }     
    }
}

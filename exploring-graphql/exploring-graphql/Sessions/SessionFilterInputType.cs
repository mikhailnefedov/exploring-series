using exploring_graphql.Models;
using HotChocolate.Data.Filters;

namespace exploring_graphql.Sessions
{
    public class SessionFilterInputType : FilterInputType<Session>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Session> descriptor)
        {
            descriptor.Ignore(t => t.Id);
            descriptor.Ignore(t => t.TrackId);
        }

    }
}

using exploring_graphql.Common;
using exploring_graphql.Models;

namespace exploring_graphql.Sessions
{
    public class AddSessionPayload : SessionPayloadBase
    {
        public AddSessionPayload(UserError error)
            : base(new[] { error })
        {
        }

        public AddSessionPayload(Session session) : base(session)
        {
        }

        public AddSessionPayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }
}

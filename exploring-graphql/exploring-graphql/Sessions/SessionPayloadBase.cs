using exploring_graphql.Common;
using exploring_graphql.Models;

namespace exploring_graphql.Sessions
{
    public class SessionPayloadBase : Payload
    {
        public Session? Session { get; }

        protected SessionPayloadBase(Session session)
        {
            Session = session;
        }

        protected SessionPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
        {
        }


    }
}

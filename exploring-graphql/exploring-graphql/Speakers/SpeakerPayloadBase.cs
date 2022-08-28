using exploring_graphql.Common;
using exploring_graphql.Models;

namespace exploring_graphql.Speakers
{
    public class SpeakerPayloadBase : Payload
    {
        public Speaker? Speaker { get; }

        protected SpeakerPayloadBase(Speaker speaker)
        {
            Speaker = speaker;
        }

        protected SpeakerPayloadBase(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}

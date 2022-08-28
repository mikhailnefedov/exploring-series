using exploring_graphql.Common;
using exploring_graphql.Models;

namespace exploring_graphql.Speakers
{
    public class AddSpeakerPayload : SpeakerPayloadBase
    {
        public AddSpeakerPayload(Speaker speaker) : base(speaker)
        {
        }

        public AddSpeakerPayload(IReadOnlyList<UserError> errors) : base(errors)
        {

        }
    }
}

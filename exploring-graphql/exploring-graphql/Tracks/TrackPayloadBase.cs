using exploring_graphql.Common;
using exploring_graphql.Models;

namespace exploring_graphql.Tracks
{
    public class TrackPayloadBase : Payload
    {
        public Track? Track { get; }

        public TrackPayloadBase(Track track)
        {
            Track = track;
        }

        public TrackPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}

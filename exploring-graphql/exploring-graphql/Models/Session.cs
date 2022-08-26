namespace exploring_graphql.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public TimeSpan Duration =>
            EndTime?.Subtract(StartTime ?? EndTime ?? DateTimeOffset.MinValue) ??
                TimeSpan.Zero;
        public int? TrackId { get; set; }
        public ICollection<SessionSpeaker> SessionSpeakers { get; set; } =
            new List<SessionSpeaker>();
        public ICollection<SessionAttendee> SessionAttendees { get; set; } =
            new List<SessionAttendee>();
        public Track? Track { get; set; }

    }
}

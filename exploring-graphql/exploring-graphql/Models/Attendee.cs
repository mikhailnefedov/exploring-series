using System.ComponentModel.DataAnnotations;

namespace exploring_graphql.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }

        public ICollection<SessionAttendee> SessionAttendees { get; set; } =
            new List<SessionAttendee>();
    }
}

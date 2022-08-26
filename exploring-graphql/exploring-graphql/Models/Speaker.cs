namespace exploring_graphql.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public virtual string? WebSite { get; set; }
        public ICollection<SessionSpeaker> SessionSpeakers { get; set; } =
            new List<SessionSpeaker>();

    }
}

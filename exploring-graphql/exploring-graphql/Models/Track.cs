namespace exploring_graphql.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Session> Sessions { get; set; } =
            new List<Session>();
    }
}

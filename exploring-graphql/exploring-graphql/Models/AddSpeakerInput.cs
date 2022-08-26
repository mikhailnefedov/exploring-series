namespace exploring_graphql.Models
{
    public record AddSpeakerInput(
        string Name,
        string? Bio,
        string? WebSite);
}

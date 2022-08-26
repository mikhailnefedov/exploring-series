namespace exploring_graphql.Models
{
    public class AddSpeakerPayload
    {
        public Speaker Speaker { get; }
        public AddSpeakerPayload(Speaker speaker)
        {
            Speaker = speaker;
        }
    }
}

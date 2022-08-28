namespace exploring_graphql.Common
{
    public abstract class Payload
    {
        public IReadOnlyList<UserError>? Errors { get; set; }

        protected Payload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }
    }
}

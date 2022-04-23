namespace Application
{
    public class QueryException : Exception
    {
        public QueryException(string entity, string message) : base(message)
        {
            Entity = entity;
        }

        public QueryException(string message) : base(message)
        {
        }

        public string? Entity { get; set; }
    }
}

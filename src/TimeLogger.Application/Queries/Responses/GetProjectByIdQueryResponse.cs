namespace TimeLogger.Application.Queries.Responses
{
    public class GetProjectByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
    }
}

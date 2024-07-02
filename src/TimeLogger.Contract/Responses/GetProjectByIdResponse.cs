namespace TimeLogger.Contract.Responses
{
    public class GetProjectByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
    }
}

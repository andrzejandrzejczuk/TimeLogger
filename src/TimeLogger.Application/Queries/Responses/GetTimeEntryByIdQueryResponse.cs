using TimeLogger.Domain;

namespace TimeLogger.Application.Queries.Responses
{
    public class GetTimeEntryByIdQueryResponse
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime Date { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public string Activity { get; set; } = default!;
    }
}

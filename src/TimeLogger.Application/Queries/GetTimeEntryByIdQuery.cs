using MediatR;
using TimeLogger.Application.Queries.Responses;

namespace TimeLogger.Application.Queries
{
    public class GetTimeEntryByIdQuery : IRequest<Result<GetTimeEntryByIdQueryResponse>>
    {
        public Guid Id { get; set; }
    }
}

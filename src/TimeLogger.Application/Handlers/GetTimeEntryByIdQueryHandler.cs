using MediatR;
using TimeLogger.Application.Queries;
using TimeLogger.Application.Queries.Responses;

namespace TimeLogger.Application.Handlers
{
    public class GetTimeEntryByIdQueryHandler : IRequestHandler<GetTimeEntryByIdQuery, GetTimeEntryByIdQueryResponse>
    {
        public Task<GetTimeEntryByIdQueryResponse> Handle(GetTimeEntryByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetTimeEntryByIdQueryResponse { });
        }
    }
}

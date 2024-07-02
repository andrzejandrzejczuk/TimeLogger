using MediatR;
using TimeLogger.Application.Queries;
using TimeLogger.Application.Queries.Responses;

namespace TimeLogger.Application.Handlers
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, GetProjectByIdQueryResponse>
    {
        public Task<GetProjectByIdQueryResponse> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetProjectByIdQueryResponse
            {
                Id = request.Id,
                Name = "Test Project"
            });
        }
    }
}

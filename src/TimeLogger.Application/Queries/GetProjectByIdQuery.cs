using MediatR;
using TimeLogger.Application.Queries.Responses;

namespace TimeLogger.Application.Queries
{
    public class GetProjectByIdQuery : IRequest<GetProjectByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}

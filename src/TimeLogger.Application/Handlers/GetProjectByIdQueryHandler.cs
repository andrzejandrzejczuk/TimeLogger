using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TimeLogger.Application.Queries;
using TimeLogger.Application.Queries.Responses;
using TimeLogger.Infrastructure;

namespace TimeLogger.Application.Handlers
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Result<GetProjectByIdQueryResponse>>
    {
        private readonly TimeLoggerDbContext _dbContext;

        public GetProjectByIdQueryHandler(TimeLoggerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<GetProjectByIdQueryResponse>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (result == null)
            {
                return Result<GetProjectByIdQueryResponse>.Failure("Project not found", (int)HttpStatusCode.NotFound);
            }

            return Result<GetProjectByIdQueryResponse>.Success(new GetProjectByIdQueryResponse
            {
                Id = result.Id,
                Name = result.Name
            });
        }
    }
}

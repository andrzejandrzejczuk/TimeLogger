using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TimeLogger.Application.Queries;
using TimeLogger.Application.Queries.Responses;
using TimeLogger.Infrastructure;

namespace TimeLogger.Application.Handlers
{
    public class GetTimeEntryByIdQueryHandler : IRequestHandler<GetTimeEntryByIdQuery, Result<GetTimeEntryByIdQueryResponse>>
    {
        private TimeLoggerDbContext _dbContext;

        public GetTimeEntryByIdQueryHandler(TimeLoggerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<GetTimeEntryByIdQueryResponse>> Handle(GetTimeEntryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.TimeEntries.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (result == null)
            {
                return Result<GetTimeEntryByIdQueryResponse>.Failure("Project not found", (int)HttpStatusCode.NotFound);
            }

            return Result<GetTimeEntryByIdQueryResponse>.Success(new GetTimeEntryByIdQueryResponse
            {
                Id = result.Id,
                Activity = result.Activity,
                Date = result.Date,
                Hours = result.Hours,
                Minutes = result.Minutes,
                ProjectId = result.ProjectId
            });
        }
    }
}

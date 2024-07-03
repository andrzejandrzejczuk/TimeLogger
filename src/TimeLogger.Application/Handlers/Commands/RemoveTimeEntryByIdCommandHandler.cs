using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TimeLogger.Application.Commands;
using TimeLogger.Application.Commands.Responses;
using TimeLogger.Infrastructure;

namespace TimeLogger.Application.Handlers.Commands
{
    public class RemoveTimeEntryByIdCommandHandler : IRequestHandler<RemoveTimeEntryByIdCommand, Result<RemoveTimeEntryByIdCommandResponse>>
    {
        private readonly TimeLoggerDbContext _dbContext;

        public RemoveTimeEntryByIdCommandHandler(TimeLoggerDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(TimeLoggerDbContext));
        }

        public async Task<Result<RemoveTimeEntryByIdCommandResponse>> Handle(RemoveTimeEntryByIdCommand request, CancellationToken cancellationToken)
        {
            var timeEntry = await _dbContext.TimeEntries.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (timeEntry == null)
            {
                return Result<RemoveTimeEntryByIdCommandResponse>.Failure("Time Entry not found", (int)HttpStatusCode.NotFound);
            }

            _dbContext.Remove(timeEntry);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<RemoveTimeEntryByIdCommandResponse>.Success(new RemoveTimeEntryByIdCommandResponse
            {
                Id = request.Id
            });
        }
    }
}

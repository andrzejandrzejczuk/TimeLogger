using MediatR;
using TimeLogger.Application.Commands.Responses;
using TimeLogger.Application.Commands;
using TimeLogger.Infrastructure;
using TimeLogger.Domain;

namespace TimeLogger.Application.Handlers
{
    public class CreateTimeEntryCommandHandler : IRequestHandler<CreateTimeEntryCommand, Result<CreateTimeEntryCommandResponse>>
    {
        private readonly TimeLoggerDbContext _dbContext;

        public CreateTimeEntryCommandHandler(TimeLoggerDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(TimeLoggerDbContext));
        }

        public async Task<Result<CreateTimeEntryCommandResponse>> Handle(CreateTimeEntryCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            
            await _dbContext.TimeEntries.AddAsync(new TimeEntry
            {
                Id = id,
                Date = request.Date,
                Hours = request.Time.Hours,
                Minutes = request.Time.Minutes,
                ProjectId = request.ProjectId,
                Activity = request.Activity,
            }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<CreateTimeEntryCommandResponse>.Success(new CreateTimeEntryCommandResponse
            {
                Id = id
            });
        }
    }
}

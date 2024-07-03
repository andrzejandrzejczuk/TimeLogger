using MediatR;
using System.Net;
using TimeLogger.Application.Commands;
using TimeLogger.Application.Commands.Responses;
using TimeLogger.Domain;
using TimeLogger.Infrastructure;

namespace TimeLogger.Application.Handlers.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result<CreateProjectCommandResponse>>
    {
        private readonly TimeLoggerDbContext _dbContext;

        public CreateProjectCommandHandler(TimeLoggerDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(TimeLoggerDbContext));
        }

        public async Task<Result<CreateProjectCommandResponse>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();

            await _dbContext.AddAsync(new Project
            {
                Id = id,
                Name = request.Name,
            }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<CreateProjectCommandResponse>.Success(new CreateProjectCommandResponse { Id = id });
        }
    }
}

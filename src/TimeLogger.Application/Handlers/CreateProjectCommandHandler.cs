using MediatR;
using System.Net;
using TimeLogger.Application.Commands;
using TimeLogger.Application.Commands.Responses;
using TimeLogger.Domain;
using TimeLogger.Infrastructure;

namespace TimeLogger.Application.Handlers
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result<CreateProjectCommandResponse>>
    {
        private readonly TimeLoggerDbContext _dbContext;

        public CreateProjectCommandHandler(TimeLoggerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<CreateProjectCommandResponse>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if(request == null || string.IsNullOrWhiteSpace(request.Name))
            {
                return Result<CreateProjectCommandResponse>.Failure("Name cannot be null or white space", (int)HttpStatusCode.BadRequest);
            }

            var id = Guid.NewGuid();

            await _dbContext.AddAsync(new Project
            {
                Id = id,
                Name = request.Name,
            });

            await _dbContext.SaveChangesAsync();

            return Result<CreateProjectCommandResponse>.Success(new CreateProjectCommandResponse { Id = id });
        }
    }
}

using MediatR;
using TimeLogger.Application.Commands;
using TimeLogger.Application.Commands.Responses;

namespace TimeLogger.Application.Handlers
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectCommandResponse>
    {
        public Task<CreateProjectCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreateProjectCommandResponse { Id = Guid.NewGuid() });
        }
    }
}

using MediatR;
using TimeLogger.Application.Commands.Responses;
using TimeLogger.Application.Commands;

namespace TimeLogger.Application.Handlers
{
    public class CreateTimeEntryCommandHandler : IRequestHandler<CreateTimeEntryCommand, CreateTimeEntryCommandResponse>
    {
        public Task<CreateTimeEntryCommandResponse> Handle(CreateTimeEntryCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreateTimeEntryCommandResponse { Id = Guid.NewGuid() });
        }
    }
}

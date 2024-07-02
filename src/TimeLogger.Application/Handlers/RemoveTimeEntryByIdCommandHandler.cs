using MediatR;
using TimeLogger.Application.Commands;
using TimeLogger.Application.Commands.Responses;

namespace TimeLogger.Application.Handlers
{
    public class RemoveTimeEntryByIdCommandHandler : IRequestHandler<RemoveTimeEntryByIdCommand, RemoveTimeEntryByIdCommandResponse>
    {
        public Task<RemoveTimeEntryByIdCommandResponse> Handle(RemoveTimeEntryByIdCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new RemoveTimeEntryByIdCommandResponse());
        }
    }
}

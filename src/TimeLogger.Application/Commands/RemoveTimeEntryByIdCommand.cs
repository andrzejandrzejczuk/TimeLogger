using MediatR;
using TimeLogger.Application.Commands.Responses;

namespace TimeLogger.Application.Commands
{
    public class RemoveTimeEntryByIdCommand : IRequest<Result<RemoveTimeEntryByIdCommandResponse>>
    {
        public Guid Id { get; set; }
    }
}

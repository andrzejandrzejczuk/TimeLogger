using MediatR;
using TimeLogger.Application.Commands.Responses;

namespace TimeLogger.Application.Commands
{
    public class RemoveTimeEntryByIdCommand : IRequest<RemoveTimeEntryByIdCommandResponse>
    {
        public Guid Id { get; set; }
    }
}

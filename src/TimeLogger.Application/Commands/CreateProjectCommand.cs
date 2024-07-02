using MediatR;
using TimeLogger.Application.Commands.Responses;

namespace TimeLogger.Application.Commands
{
    public class CreateProjectCommand : IRequest<CreateProjectCommandResponse>
    {
        public string Name { get; set; } = default!;
    }
}

using MediatR;
using TimeLogger.Application.Commands.Responses;

namespace TimeLogger.Application.Commands
{
    public class CreateProjectCommand : IRequest<Result<CreateProjectCommandResponse>>
    {
        public string Name { get; set; } = default!;
    }
}

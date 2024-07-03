using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TimeLogger.Application.Commands;
using TimeLogger.Application.Queries;
using TimeLogger.Contract.Requests;
using TimeLogger.Contract.Responses;

namespace TimeLogger.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectsController(
            IMediator mediator, 
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(IMediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateProjectResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<CreateProjectCommand>(request);
            
            var commandResponse = await _mediator.Send(command, cancellationToken);

            if (!commandResponse.IsSuccess)
            {
                return StatusCode(commandResponse.StatusCode, new { error = commandResponse.Error });
            }

            var createProjectResponse = _mapper.Map<CreateProjectResponse>(commandResponse.Value);

            return CreatedAtAction(nameof(GetById), new { id = createProjectResponse.Id }, createProjectResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetProjectByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProjectByIdQuery { Id = id };
            
            var getProjectByIdQueryResponse = await _mediator.Send(query, cancellationToken);

            if (!getProjectByIdQueryResponse.IsSuccess)
            {
                return StatusCode(getProjectByIdQueryResponse.StatusCode, new { error = getProjectByIdQueryResponse.Error });
            }

            var getByIdResponse = _mapper.Map<GetProjectByIdResponse>(getProjectByIdQueryResponse.Value);

            return Ok(getByIdResponse);
        }
    }
}

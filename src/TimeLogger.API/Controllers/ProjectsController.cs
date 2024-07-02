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
        public async Task<IActionResult> Create([FromBody] CreateProjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<CreateProjectCommand>(request);
            
            var commandResponse = await _mediator.Send(command);

            var createProjectResponse = _mapper.Map<CreateProjectResponse>(commandResponse);

            return CreatedAtAction(nameof(GetById), new { id = createProjectResponse.Id }, createProjectResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetProjectByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProjectByIdQuery { Id = id };
            
            var getProjectByIdQueryResponse = await _mediator.Send(query);

            if (getProjectByIdQueryResponse == null)
            {
                return NotFound();
            }

            var getByIdResponse = _mapper.Map<GetProjectByIdResponse>(getProjectByIdQueryResponse);

            return Ok(getByIdResponse);
        }
    }
}

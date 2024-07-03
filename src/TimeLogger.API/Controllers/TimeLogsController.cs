using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TimeLogger.Application.Commands;
using TimeLogger.Application.Queries;
using TimeLogger.Application.Queries.Responses;
using TimeLogger.Contract.Requests;
using TimeLogger.Contract.Responses;

namespace TimeLogger.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class TimeLogsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TimeLogsController(
            IMediator mediator, 
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(IMediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateTimeEntryResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateTimeEntryRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<CreateTimeEntryCommand>(request);
            var commandResponse = await _mediator.Send(command, cancellationToken);

            if (!commandResponse.IsSuccess)
            {
                return StatusCode(commandResponse.StatusCode, new { error = commandResponse.Error });
            }

            var response = _mapper.Map<CreateTimeEntryResponse>(commandResponse.Value);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new RemoveTimeEntryByIdCommand { Id = id };

            var commandResponse = await _mediator.Send(command, cancellationToken);

            if(commandResponse.IsSuccess)
            {
                return StatusCode(commandResponse.StatusCode, new { error = commandResponse.Error });
            }

            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetTimeEntryByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetTimeEntryByIdQuery { Id = id };

            var queryResponse = await _mediator.Send(query, cancellationToken);

            if (!queryResponse.IsSuccess)
            {
                return StatusCode(queryResponse.StatusCode, new { error = queryResponse.Error });
            }

            var getByIdResponse = _mapper.Map<GetTimeEntryByIdResponse>(queryResponse.Value);

            return Ok(getByIdResponse);
        }
    }
}

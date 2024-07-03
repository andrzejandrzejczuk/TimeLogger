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
        public async Task<IActionResult> Create([FromBody] CreateTimeEntryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<CreateTimeEntryCommand>(request);
            var commandResponse = await _mediator.Send(command);
            var response = _mapper.Map<CreateTimeEntryResponse>(commandResponse);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new RemoveTimeEntryByIdCommand { Id = id };

            var removeTimeEntryByIdCommandResponse = await _mediator.Send(command);

            if(removeTimeEntryByIdCommandResponse == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetTimeEntryByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetTimeEntryByIdQuery { Id = id };

            var getTimeEntryByIdQueryResponse = await _mediator.Send(query);

            if (getTimeEntryByIdQueryResponse == null)
            {
                return NotFound();
            }

            var getByIdResponse = _mapper.Map<GetTimeEntryByIdResponse>(getTimeEntryByIdQueryResponse);

            return Ok(getByIdResponse);
        }
    }
}

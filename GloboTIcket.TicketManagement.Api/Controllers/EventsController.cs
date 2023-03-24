using GloboTIcket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTIcket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTIcket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTIcket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTIcket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using GloboTIcket.TicketManagement.Application.Features.Events.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            var events = await _mediator.Send(new GetEventsListQuery());
            return Ok(events);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventListVm>> GetEventById(Guid id)
        {
            var eventDetail = await _mediator.Send(new GetEventDetailQuery { Id = id });
            return Ok(eventDetail);
        }

        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<CreateEventCommand>> CreateEvent([FromBody] CreateEventCommand createEventCommand)
        {
            var response = await _mediator.Send(createEventCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEventCommand { EventId = id });
            return NoContent();
        }

        [HttpGet("Export", Name = "ExportEvents")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDto = await _mediator.Send(new GetEventsExportQuery());
            return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);
        }
    }
}
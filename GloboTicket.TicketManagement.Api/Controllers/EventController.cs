using GloboTicket.TicketManagement.Api.Utility;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name ="GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            var listOfEvents = await _mediator.Send(new GetEventsListQuery());
            return Ok(listOfEvents);
        }

        [HttpGet("{eventId:Guid}", Name = "GetEventById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EventDetailVm>> GetEventById([FromRoute]Guid eventId)
        {
            var eventDetail = await _mediator.Send(new GetEventDetailQuery() { Id = eventId});
            return Ok(eventDetail);
        }

        [HttpPost(Name ="CreateEvent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateEvent([FromBody] CreateEventCommand createEventCommand)
        {
            var eventId = await _mediator.Send(createEventCommand);
            return Ok(eventId);
        }

        [HttpPut(Name ="UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateEvent([FromBody] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{eventId:Guid}",Name ="DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteEvent([FromRoute] Guid eventId)
        {
            await _mediator.Send(new DeleteEventCommand() { EventId = eventId});
            return NoContent();
        }

        [HttpGet("export", Name = "ExportEvents")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDTO = await _mediator.Send(new GetEventsExportQuery());
            return File(fileDTO.Data, fileDTO.ContentType, fileDTO.EventExportFileName);
        }
    }
}

using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0) throw new Exceptions.ValidationException(validationResult);
            @event = await _eventRepository.AddAsync(@event);

            // Sending email notification to admin address
            var email = new Email { To = "asd@asd.com", Body = $"A new event was created {request}", Subject = "A new event created" };
            try
            {
                await _emailService.SendEmail(email);
            }catch(Exception e)
            {

            }
            return @event.EventId;
        }
    }
}

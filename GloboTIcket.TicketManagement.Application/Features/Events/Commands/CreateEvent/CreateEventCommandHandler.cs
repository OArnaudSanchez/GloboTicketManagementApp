using AutoMapper;
using GloboTIcket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTIcket.TicketManagement.Application.Contracts.Persistance;
using GloboTIcket.TicketManagement.Application.Exceptions;
using GloboTIcket.TicketManagement.Application.Models.Mail;
using GloboTIcket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Application.Features.Events.Commands.CreateEvent
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
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var @event = _mapper.Map<Event>(request);
            @event = await _eventRepository.AddAsync(@event);
            try
            {
                var email = new Email
                {
                    To = "oarnaudsanchez23@gmail.com",
                    Body = $"A new event was created: {request}",
                    Subject = "A new event was created"
                };
                await _emailService.SendEmail(email);
            }
            catch (Exception)
            {
                throw;
            }
            return @event.EventId;
        }
    }
}
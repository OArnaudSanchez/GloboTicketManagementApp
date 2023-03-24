using AutoMapper;
using GloboTIcket.TicketManagement.Application.Contracts.Persistance;
using GloboTIcket.TicketManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var currentEvent = await _eventRepository.GetByIdAsync(request.EventId);
            _mapper.Map(request, currentEvent, typeof(UpdateEventCommand), typeof(Event));
            await _eventRepository.UpdateAsync(currentEvent);
            return Unit.Value;
        }
    }
}
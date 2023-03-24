using AutoMapper;
using GloboTIcket.TicketManagement.Application.Contracts.Persistance;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        private readonly IMapper _mapper;

        public DeleteEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var currentEvent = await _eventRepository.GetByIdAsync(request.EventId);
            await _eventRepository.DeleteAsync(currentEvent);
            return Unit.Value;
        }
    }
}
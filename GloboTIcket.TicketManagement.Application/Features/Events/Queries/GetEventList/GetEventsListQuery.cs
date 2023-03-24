using MediatR;
using System.Collections.Generic;

namespace GloboTIcket.TicketManagement.Application.Features.Events.Queries.List
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {
    }
}
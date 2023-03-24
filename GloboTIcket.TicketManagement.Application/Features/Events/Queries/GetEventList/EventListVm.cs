using System;

namespace GloboTIcket.TicketManagement.Application.Features.Events.Queries.List
{
    //This class should be in its own View Models Folder
    public class EventListVm
    {
        public Guid EventId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }
    }
}